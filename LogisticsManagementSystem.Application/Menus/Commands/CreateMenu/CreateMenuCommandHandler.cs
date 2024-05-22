using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class CreateMenuCommandHandler(IMenuRepository _menuRepository) : IRequestHandler<CreateMenuCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateMenuCommand command, CancellationToken cancellationToken)
    {
        if (command.Controller is not null)
        {
            var controller = await _menuRepository.IsMenuControllerExists(command.Controller);
            if (controller)
                return Error.Conflict(description: "控制器已存在");
        }

        var menu = new Menu(command.ParentId, command.Name, command.Controller, command.Path, command.Icon, command.Component, command.Visibility);

        await _menuRepository.CreateAsync(menu, cancellationToken);

        return Result.Created;
    }
}
