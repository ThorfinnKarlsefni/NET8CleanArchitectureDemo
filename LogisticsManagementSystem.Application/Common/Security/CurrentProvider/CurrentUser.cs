namespace LogisticsManagementSystem.Application;

public record CurrentUser(
    Guid Id,
    string Name,
    List<Guid> CompanyIds,
    IReadOnlyList<string> Permissions,
    IReadOnlyList<string> Roles,
    string SecurityStamp
);
