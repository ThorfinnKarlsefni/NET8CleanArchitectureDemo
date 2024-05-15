
namespace LogisticsManagementSystem.Application;

public record ListUserResult(
    long TotalCount,
    int PageNumber,
    int Pagesize,
    List<ListUser> Users
);

public record ListUser(
    Guid Id,
    string? UserName,
    string Name,
    string? Avatar,
    string? PhoneNumber,
    DateTime CreatedAt,
    List<ListUserRoleResult> Roles,
    UserCompanyResult? Company
  );

public record ListUserRoleResult(Guid Id, string Name);

public record UserCompanyResult(Guid? Id, string? CompanyName);
