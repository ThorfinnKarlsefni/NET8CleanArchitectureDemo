using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class DeletePermissionCommandHandler(
    IPermissionRepository _permissionRepository,
    IRolePermissionRepository _rolePermissionRepository) : IRequestHandler<DeletePermissionCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeletePermissionCommand command, CancellationToken cancellationToken)
    {
        var permissionItem = await _rolePermissionRepository.GetPermissionByPermissionIdAsync(command.PermissionId, cancellationToken);

        if (permissionItem is not null)
        {
            return Error.Conflict(description: "请先清除角色绑定的权限");
        }

        var permission = await _permissionRepository.GetByIdAsync(command.PermissionId, cancellationToken);

        if (permission is null)
        {
            return Error.NotFound(description: "权限未找到");
        }

        permission.SetDeletedAt();
        await _permissionRepository.UpdateAsync(permission, cancellationToken);

        return Result.Deleted;
    }
}
