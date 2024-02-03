namespace LogisticsManagementSystem.Infrastructure;

public record CurrentUser(
    string Id,
    string Name,
    string? CompanyId,
    // IReadOnlyList<string>? Permissions,
    IReadOnlyList<string>? Roles
);
