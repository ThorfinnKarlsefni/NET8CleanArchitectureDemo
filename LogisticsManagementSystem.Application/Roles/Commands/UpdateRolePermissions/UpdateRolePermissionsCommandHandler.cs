using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class UpdateRolePermissionsCommandHandler(
    IRolePermissionRepository _rolePermissionRepository,
    IRoleRepository _roleRepository
) : IRequestHandler<UpdateRolePermissionsCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateRolePermissionsCommand command, CancellationToken cancellationToken)
    {

        var role = await _roleRepository.FindByIdAsync(command.RoleId, cancellationToken);
        if (role is null)
        {
            return Error.Validation(description: "角色不存在");
        }

        var currentRolePermissions = await _rolePermissionRepository.GetPermissionsByRoleIdAsync(command.RoleId, cancellationToken);

        if (currentRolePermissions.Any())
        {
            await _rolePermissionRepository.DeleteRangeAsync(currentRolePermissions, cancellationToken);
        }

        var rolePermissions = command.PermissionIds.Select(permissionsId => new RolePermissions(permissionsId, command.RoleId)).ToList();

        await _rolePermissionRepository.CreateRangeAsync(rolePermissions, cancellationToken);

        return Result.Updated;
    }
}
