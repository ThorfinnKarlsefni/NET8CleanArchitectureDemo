using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;
using Microsoft.VisualBasic;

namespace LogisticsManagementSystem.Application;

public class CreateMenuCommandHandler(IMenuRepository _menuRepository) : IRequestHandler<CreateMenuCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateMenuCommand command, CancellationToken cancellationToken)
    {
        if (command.Controller is not null)
        {
            var controller = await _menuRepository.CheckControllerAsync(command.Controller.Trim());
            if (controller)
                return Error.Conflict(description: "控制器已存在");
        }

        var menu = new Menu(command.ParentId, command.Name, command.Controller?.Trim(), command.Path, command.Icon, command.Component, command.Visibility);
        await _menuRepository.AddAsync(menu, cancellationToken);
        return Result.Created;
    }
}
