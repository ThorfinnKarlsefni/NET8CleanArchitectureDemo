using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace LogisticsManagementSystem.Infrastructure;

public class PasswordEncryption : IPasswordEncryption
{
    private const int IterationCount = 100000; // 设置迭代次数
    private const int SaltSize = 128 / 8; // 盐的大小为128位，即16字节
    private const int SubkeyLength = 256 / 8; // 子密钥长度为256位，即32字节

    public string HashPassword(string password)
    {
        byte[] salt = GenerateSalt();
        byte[] subkey = GenerateSubkey(password, salt);
        byte[] outputBytes = new byte[13 + SaltSize + SubkeyLength];
        outputBytes[0] = 0x01; // 格式标记
        WriteNetworkByteOrder(outputBytes, 1, (uint)KeyDerivationPrf.HMACSHA512);
        WriteNetworkByteOrder(outputBytes, 5, (uint)IterationCount);
        WriteNetworkByteOrder(outputBytes, 9, (uint)SaltSize);
        Buffer.BlockCopy(salt, 0, outputBytes, 13, SaltSize);
        Buffer.BlockCopy(subkey, 0, outputBytes, 13 + SaltSize, SubkeyLength);
        return Convert.ToBase64String(outputBytes);
    }

    public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
    {
        byte[] decodedHashedPassword = Convert.FromBase64String(hashedPassword);
        int iterCount;
        KeyDerivationPrf prf;
        if (decodedHashedPassword.Length != (13 + SaltSize + SubkeyLength) ||
            decodedHashedPassword[0] != 0x01 ||
            !Enum.TryParse(((uint)ReadNetworkByteOrder(decodedHashedPassword, 1)).ToString(), out prf) ||
            (iterCount = (int)ReadNetworkByteOrder(decodedHashedPassword, 5)) < 1 ||
            (int)ReadNetworkByteOrder(decodedHashedPassword, 9) != SaltSize)
        {
            // 无效的哈希格式
            return false;
        }
        byte[] salt = new byte[SaltSize];
        Buffer.BlockCopy(decodedHashedPassword, 13, salt, 0, SaltSize);
        byte[] expectedSubkey = new byte[SubkeyLength];
        Buffer.BlockCopy(decodedHashedPassword, 13 + SaltSize, expectedSubkey, 0, SubkeyLength);
        byte[] actualSubkey = GenerateSubkey(providedPassword, salt);
        return ByteArraysEqual(actualSubkey, expectedSubkey);
    }

    private byte[] GenerateSalt()
    {
        byte[] salt = new byte[SaltSize];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    private byte[] GenerateSubkey(string password, byte[] salt)
    {
        return KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA512, IterationCount, SubkeyLength);
    }

    private bool ByteArraysEqual(byte[] a, byte[] b)
    {
        if (a == null && b == null)
        {
            return true;
        }
        if (a == null || b == null || a.Length != b.Length)
        {
            return false;
        }
        bool areSame = true;
        for (int i = 0; i < a.Length; i++)
        {
            areSame &= (a[i] == b[i]);
        }
        return areSame;
    }

    private uint ReadNetworkByteOrder(byte[] buffer, int offset)
    {
        return ((uint)(buffer[offset + 0]) << 24) |
               ((uint)(buffer[offset + 1]) << 16) |
               ((uint)(buffer[offset + 2]) << 8) |
               ((uint)(buffer[offset + 3]));
    }

    private void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
    {
        buffer[offset + 0] = (byte)(value >> 24);
        buffer[offset + 1] = (byte)(value >> 16);
        buffer[offset + 2] = (byte)(value >> 8);
        buffer[offset + 3] = (byte)(value >> 0);
    }

    public string GenerateSecurityStamp()
    {
        const int length = 32;
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        char[] randomChars = new char[length];
        using (var rng = RandomNumberGenerator.Create())
        {
            byte[] randomBytes = new byte[length];
            rng.GetBytes(randomBytes);
            for (int i = 0; i < length; i++)
            {
                randomChars[i] = chars[randomBytes[i] % chars.Length];
            }
        }
        return new string(randomChars);
    }
}
