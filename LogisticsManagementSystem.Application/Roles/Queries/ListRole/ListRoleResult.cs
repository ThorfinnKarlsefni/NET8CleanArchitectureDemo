namespace LogisticsManagementSystem.Application;

public record ListRoleResult(
    long TotalCount,
    int PageNumber,
    int Pagesize,
    List<ListRole> Roles
);

public record ListRole(
    Guid Id,
    string? Name,
    string? NormalizedName,
    DateTime CreatedAt
);