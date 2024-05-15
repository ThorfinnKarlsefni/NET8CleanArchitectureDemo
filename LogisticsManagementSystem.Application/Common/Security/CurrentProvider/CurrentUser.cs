namespace LogisticsManagementSystem.Application;

public record CurrentUser(
    Guid Id,
    string Name,
    string CompanyId,
    IReadOnlyList<string> Permissions,
    IReadOnlyList<string> Roles,
    string SecurityStamp
);
