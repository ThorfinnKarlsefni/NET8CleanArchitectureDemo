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

    public async Task<ErrorOr<Updated>> Handle(VisibilityMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = await _menuRepository.GetByIdAsync(request.Id);
        if (menu is null)
            return Error.NotFound();

        menu.HideOrShow(menu.Visibility);
        await _menuRepository.SaveChangesAsync();
        return Result.Updated;
    }
}
