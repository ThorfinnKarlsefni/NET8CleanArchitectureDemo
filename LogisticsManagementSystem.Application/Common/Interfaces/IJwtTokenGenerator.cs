namespace LogisticsManagementSystem.Application;

public interface IJwtTokenGenerator
{
  string GenerateToken(
      Guid id,
      string name,
      List<Guid> companyIds,
      List<string> roles,
      List<string?> permissions,
      string securityStamp
    );
}
