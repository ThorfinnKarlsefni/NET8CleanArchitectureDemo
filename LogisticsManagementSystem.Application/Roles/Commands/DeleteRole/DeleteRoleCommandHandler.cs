using System.Globalization;
using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class DeleteRoleCommandHandler(IRoleRepository _roleRepository, IUserRolesRepository _userRolesRepository) : IRequestHandler<DeleteRoleCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteRoleCommand command, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.FindByIdAsync(command.RoleId, cancellationToken);
        if (role is null)
            return Error.NotFound(description: "用户不存在");

        var roles = await _userRolesRepository.GetListByRoleIdAsync(role.Id, cancellationToken);

        if (roles.Any())
        {
            return Error.Conflict(description: "有用户设置当前的角色");
        }

        role.DeleteRoleMenus(role.Id);
        role.SetDeletedAt();
        await _roleRepository.DeleteAsync(role, cancellationToken);

        return Result.Deleted;
    }
}
