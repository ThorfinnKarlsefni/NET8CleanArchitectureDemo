namespace LogisticsManagementSystem.Infrastructure;

public interface IPasswordEncryption
{
    string GenerateSecurityStamp();
    string HashPassword(string password);
    bool VerifyHashedPassword(string hashedPassword, string providedPassword);
}
