using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class UpdateMenuCommandHandler(IMenuRepository _menuRepository) : IRequestHandler<UpdateMenuCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateMenuCommand command, CancellationToken cancellationToken)
    {
        var menu = await _menuRepository.GetByIdAsync(command.MenuId, cancellationToken);

        if (menu is null)
        {
            return Error.NotFound("菜单未找到");
        }

        menu.UpdateMenu(command.ParentId, command.Name, command.Path, command.Controller, command.Component, command.Icon, command.Sort, command.Visibility);

        await _menuRepository.UpdateAsync(menu, cancellationToken);

        return Result.Updated;
    }
}
