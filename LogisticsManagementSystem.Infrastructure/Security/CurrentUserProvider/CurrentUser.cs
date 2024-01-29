namespace LogisticsManagementSystem.Infrastructure;

public record CurrentUser(
    Guid Id,
    string Name,
    string Company,
    IReadOnlyList<string> Permissions,
    IReadOnlyList<string> Roles
);
