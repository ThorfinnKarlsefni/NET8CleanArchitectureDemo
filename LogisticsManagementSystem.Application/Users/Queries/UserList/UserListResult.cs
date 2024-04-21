namespace LogisticsManagementSystem.Application;

public record UserListResult(
    long TotalCount,
    // int NormalCount,
    // int ForbiddenCount,
    int PageNumber,
    int Pagesize,
    List<UserList>? Users
);

public record UserList(Guid Id, string? UserName, string Name, string? Avatar, string? PhoneNumber, DateTime CreatedAt, IEnumerable<UserListRoleResult> Roles);

public record UserListRoleResult(Guid Id, string? Name);

