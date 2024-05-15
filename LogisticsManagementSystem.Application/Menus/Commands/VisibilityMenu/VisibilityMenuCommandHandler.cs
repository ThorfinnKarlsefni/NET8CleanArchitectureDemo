using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class VisibilityMenuCommandHandler(IMenuRepository _menuRepository) : IRequestHandler<VisibilityMenuCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(VisibilityMenuCommand command, CancellationToken cancellationToken)
    {
        var menu = await _menuRepository.GetByIdAsync(command.Id, cancellationToken);
        if (menu is null)
            return Error.NotFound();

        menu.HideOrShow(menu.Visibility);
        await _menuRepository.UpdateAsync(menu, cancellationToken);
        return Result.Updated;
    }
}
