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

    public async Task<ErrorOr<Updated>> Handle(UpdateMenuSortCommand request, CancellationToken cancellationToken)
    {
        foreach (var item in request.Menus)
        {
            var menu = await _menuRepository.GetByIdAsync(item.Id);
            if (menu is null)
                return Error.NotFound();
            menu.UpdateSort(item.ParentId, item.Sort);
        }

        await _menuRepository.SaveChangesAsync();
        return Result.Updated;
    }
}
