using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record UpdatePermissionSortCommand(
    List<PermissionSortItem> Permissions
) : IRequest<ErrorOr<Updated>>;
public record PermissionSortItem(
    int PermissionId,
    int? ParentId,
    int Sort
);

