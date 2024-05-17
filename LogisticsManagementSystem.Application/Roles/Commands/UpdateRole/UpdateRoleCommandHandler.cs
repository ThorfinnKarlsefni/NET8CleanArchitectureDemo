using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class UpdateRoleCommandHandler(IRoleRepository _roleRepository) : IRequestHandler<UpdateRoleCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.FindByIdAsync(command.RoleId, cancellationToken);
        if (role is null)
            return Error.NotFound(description: "用户不存在");

        role.Update(command.Name);
        role.DeleteRoleMenus(role.Id);
        role.SetRoleMenus(role.Id, command.Menus);

        await _roleRepository.UpdateAsync(role, cancellationToken);

        return Result.Updated;
    }
}
