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

    public async Task<ErrorOr<Deleted>> Handle(DeleteMenuCommand command, CancellationToken cancellationToken)
    {
        var menu = await _menuRepository.GetByIdAsync(command.Id, cancellationToken);
        if (menu is null)
            return Error.NotFound(description: "菜单不存在");
        menu.SetDeletedAt();
        await _menuRepository.SaveChangesAsync(cancellationToken);
        return Result.Deleted;
    }
}
