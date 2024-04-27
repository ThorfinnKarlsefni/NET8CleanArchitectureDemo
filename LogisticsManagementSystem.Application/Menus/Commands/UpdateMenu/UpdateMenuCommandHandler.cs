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
        var menu = await _menuRepository.GetByIdAsync(request.Id, cancellationToken);
        if (menu is null)
            return Error.NotFound();
        menu.UpdateMenu(request.ParentId, request.Name, request.Path, request.Component, request.Icon, request.Sort, request.Visibility);

        await _menuRepository.SaveChangesAsync(cancellationToken);
        return Result.Updated;
    }
}
