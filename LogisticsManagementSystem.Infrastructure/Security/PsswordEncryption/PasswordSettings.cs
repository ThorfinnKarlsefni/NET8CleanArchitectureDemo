using LogisticsManagementSystem.Application;

namespace LogisticsManagementSystem.Infrastructure;

public class PasswordSettings : IPasswordSettings
{
    public int RequiredLength { get; set; } = 6;

    public int RequiredUniqueChars { get; set; } = 1;

    public bool RequireNonAlphanumeric { get; set; } = true;

    public bool RequireLowercase { get; set; } = true;

    public bool RequireUppercase { get; set; } = true;

    public bool RequireDigit { get; set; } = true;
}
