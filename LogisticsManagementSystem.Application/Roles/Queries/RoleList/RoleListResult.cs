namespace LogisticsManagementSystem.Application;

public record RoleListResult(
    long TotalCount,
    int PageNumber,
    int Pagesize,
    List<RoleList> Roles
);

public record RoleList(
    Guid Id,
    string? Name,
    string? NormalizedName,
    DateTime CreatedAt
);