namespace LogisticsManagementSystem.Application;

public interface IJwtTokenGenerator
{
  string GenerateToken(
      Guid id,
      string name,
      Guid? company,
      List<string> roles,
      List<string?> permissions,
      string securityStamp
    );
}
