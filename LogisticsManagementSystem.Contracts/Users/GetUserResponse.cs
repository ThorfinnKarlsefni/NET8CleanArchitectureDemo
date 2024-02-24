namespace LogisticsManagementSystem.Contracts;

public record GetUserResponse(Guid Id, string? UserName, string Name, string? Avatar, DateTime CreatedAt, IEnumerable<UserRoleResponse> Roles);

public record UserRoleResponse(Guid Id, string? Name);