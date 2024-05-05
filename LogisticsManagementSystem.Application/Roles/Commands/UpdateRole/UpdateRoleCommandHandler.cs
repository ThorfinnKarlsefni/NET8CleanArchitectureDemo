using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class UpdateRoleCommandHandler(IRoleRepository _roleRepository, IMenuRolesRepository _menuRolesRepository) : IRequestHandler<UpdateRoleCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.FindByIdAsync(command.Id.ToString());
        if (role is null)
            return Error.NotFound(description: "用户不存在");

        role.Update(command.Name, command.NormalizedName);

        await _menuRolesRepository.DeleteAsync(role.Id, cancellationToken);

        var res = await _roleRepository.UpdateAsync(role);

        if (!res.Succeeded)
        {
            return Error.Conflict(description: res.Errors.First().Description.ToString());
        }

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
