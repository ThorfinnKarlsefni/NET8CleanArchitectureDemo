namespace LogisticsManagementSystem.Application;

public record ListUserResult(
    int TotalCount,
    int Pagesize,
    int pageNumber,
    List<UserList>? Users
);

public record UserList(Guid Id, string? UserName, string Name, string? Avatar, DateTime CreatedAt, IEnumerable<ListUserRoleResult> Roles);

public record ListUserRoleResult(Guid Id, string? Name);

