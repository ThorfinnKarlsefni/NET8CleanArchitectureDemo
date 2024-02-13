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

    public async Task<ErrorOr<Updated>> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = await _menuRepository.GetByIdAsync(request.Id);
        if (menu is null)
            return Error.NotFound();
        menu.UpdateMenu(request.ParentId, request.Name, request.Path, request.Component, request.Icon, request.Rank, request.HideMenu);
        await _menuRepository.SaveChangesAsync();
        return Result.Updated;
    }
}
