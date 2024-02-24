namespace LogisticsManagementSystem.Application;

public record GetUserResult(
    Guid Id,
    string? Company,
    string? UserName,
    string Name,
    string? PhoneNumber,
    string? Email,
    DateTime CreatedAt,
    IEnumerable<GetUserRoleList> Roles);

public record GetUserRoleList(Guid Id, string? Name);