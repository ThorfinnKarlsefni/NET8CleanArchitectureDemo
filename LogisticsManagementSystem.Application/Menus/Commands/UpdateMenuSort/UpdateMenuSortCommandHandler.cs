using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class UpdateMenuSortCommandHandler(IMenuRepository _menuRepository) : IRequestHandler<UpdateMenuSortCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateMenuSortCommand command, CancellationToken cancellationToken)
    {

        var allMenus = await _menuRepository.GetListMenuAsync(onlyVisible: false, cancellationToken);

        foreach (var item in allMenus)
        {
            var updateItem = command.Menus.FirstOrDefault(x => x.Id == item.Id);
            if (updateItem is not null)
                item.UpdateSort(updateItem.ParentId, updateItem.Sort);
        }

        await _menuRepository.UpdateRangeAsync(allMenus, cancellationToken);

        return Result.Updated;
    }
}
