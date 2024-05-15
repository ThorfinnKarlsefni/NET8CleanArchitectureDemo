using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class UpdateRoleCommandHandler(IRoleRepository _roleRepository, IRoleMenusRepository _roleMenusRepository) : IRequestHandler<UpdateRoleCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.FindByIdAsync(command.RoleId, cancellationToken);
        if (role is null)
            return Error.NotFound(description: "用户不存在");

        role.Update(command.Name);

        await _roleMenusRepository.DeleteAsync(role.Id, cancellationToken);

        await _roleRepository.UpdateAsync(role, cancellationToken);

        var menuRoleRelations = command.Menus.Select(
            menuId => new RoleMenus(menuId, role.Id)
        ).ToList();

        if (menuRoleRelations.Any())
        {
            await _roleMenusRepository.AddRangeAsync(menuRoleRelations, cancellationToken);
            await _roleMenusRepository.SaveChangesAsync(cancellationToken);
        }

        return Result.Updated;
    }
}
