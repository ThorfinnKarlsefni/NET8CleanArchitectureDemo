namespace LogisticsManagementSystem.Infrastructure;

public record CurrentUser(
    Guid Id,
    string Name,
    string CompanyId,
    IReadOnlyList<string> Permissions,
    IReadOnlyList<string> Roles
);
