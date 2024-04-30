using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand, ErrorOr<Updated>>
{
    private readonly IMenuRepository _menuRepository;

    public UpdateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Updated>> Handle(UpdateMenuCommand command, CancellationToken cancellationToken)
    {
        var menu = await _menuRepository.GetByIdAsync(command.Id, cancellationToken);
        if (menu is null)
            return Error.NotFound();
        menu.UpdateMenu(command.ParentId, command.Name, command.Path, command.Component, command.Icon, command.Sort, command.Visibility);

        await _menuRepository.SaveChangesAsync(cancellationToken);
        return Result.Updated;
    }
}
