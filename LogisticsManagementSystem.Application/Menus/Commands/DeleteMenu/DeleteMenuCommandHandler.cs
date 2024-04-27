using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand, ErrorOr<Deleted>>
{
    private readonly IMenuRepository _menuRepository;

    public DeleteMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = await _menuRepository.GetByIdAsync(request.Id, cancellationToken);
        if (menu is null)
            return Error.NotFound(description: "菜单不存在");
        menu.SetDeletedAt();
        await _menuRepository.SaveChangesAsync(cancellationToken);
        return Result.Deleted;
    }
}
