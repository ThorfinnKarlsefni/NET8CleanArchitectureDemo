using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class VisibilityMenuCommandHandler : IRequestHandler<VisibilityMenuCommand, ErrorOr<Updated>>
{
    private readonly IMenuRepository _menuRepository;

    public VisibilityMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Updated>> Handle(VisibilityMenuCommand command, CancellationToken cancellationToken)
    {
        var menu = await _menuRepository.GetByIdAsync(command.Id, cancellationToken);
        if (menu is null)
            return Error.NotFound();

        menu.HideOrShow(menu.Visibility);
        await _menuRepository.SaveChangesAsync(cancellationToken);
        return Result.Updated;
    }
}
