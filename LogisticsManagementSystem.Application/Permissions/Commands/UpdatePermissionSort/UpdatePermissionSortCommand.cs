using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Policies = Policy.SelfOrAdmin)]
public record UpdatePermissionSortCommand(
    List<PermissionSortItem> Permissions
) : IAuthorizeAbleRequest<ErrorOr<Updated>>;
public record PermissionSortItem(
    int Id,
    int? ParentId,
    int Sort
);

