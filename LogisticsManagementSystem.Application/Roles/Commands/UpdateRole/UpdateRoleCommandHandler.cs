using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class UpdateRoleCommandHandler(IRoleRepository _roleRepository, IMenuRolesRepository _menuRolesRepository) : IRequestHandler<UpdateRoleCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.FindByIdAsync(command.RoleId, cancellationToken);
        if (role is null)
            return Error.NotFound(description: "用户不存在");

        role.Update(command.Name);

        await _menuRolesRepository.DeleteAsync(role.Id, cancellationToken);

        await _roleRepository.UpdateAsync(role, cancellationToken);

        // if (!res.Succeeded)
        // {
        //     return Error.Conflict(description: res.Errors.First().Description.ToString());
        // }

        var menuRoleRelations = command.Menus.Select(
            menuId => new MenuRole
            {
                RoleId = role.Id,
                MenuId = menuId
            }
        ).ToList();

        if (menuRoleRelations.Any())
        {
            await _menuRolesRepository.AddRangeAsync(menuRoleRelations, cancellationToken);
            await _menuRolesRepository.SaveChangesAsync(cancellationToken);
        }

        return Result.Updated;
    }
}
