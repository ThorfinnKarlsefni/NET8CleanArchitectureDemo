namespace LogisticsManagementSystem.Application;

public interface IJwtTokenGenerator
{
    string GenerateToken(
          Guid id,
          string name,
          string? company,
          //   List<string?> permissions,
          List<string> roles);
}
