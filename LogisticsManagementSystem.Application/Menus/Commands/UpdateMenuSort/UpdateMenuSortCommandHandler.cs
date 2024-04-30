using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class UpdateMenuSortCommandHandler : IRequestHandler<UpdateMenuSortCommand, ErrorOr<Updated>>
{
    private readonly IMenuRepository _menuRepository;

    public UpdateMenuSortCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Updated>> Handle(UpdateMenuSortCommand command, CancellationToken cancellationToken)
    {

        var allMenus = await _menuRepository.GetAllMenuListAsync(cancellationToken);

        foreach (var item in allMenus)
        {
            var updateItem = command.Menus.FirstOrDefault(x => x.Id == item.Id);
            if (updateItem is not null)
                item.UpdateSort(updateItem.ParentId, updateItem.Sort);
        }

        await _menuRepository.SaveChangesAsync(cancellationToken);
        return Result.Updated;
    }
}
