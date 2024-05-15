using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class DeleteMenuCommandHandler(IMenuRepository _menuRepository) : IRequestHandler<DeleteMenuCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteMenuCommand command, CancellationToken cancellationToken)
    {
        var menu = await _menuRepository.GetByIdAsync(command.Id, cancellationToken);
        if (menu is null)
            return Error.NotFound(description: "菜单不存在");
        menu.SetDeletedAt();
        await _menuRepository.UpdateAsync(menu, cancellationToken);
        return Result.Deleted;
    }
}
