using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record UpdatePermissionSortCommand(
    List<PermissionSortItem> Permissions
) : IRequest<ErrorOr<Updated>>;
public record PermissionSortItem(
    int Id,
    int? ParentId,
    int Sort
);

