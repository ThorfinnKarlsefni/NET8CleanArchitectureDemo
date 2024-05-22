using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GetMenuQueryHandler(IMenuRepository _menuRepository) : IRequestHandler<GetMenuQuery, ErrorOr<Menu?>>
{
    public async Task<ErrorOr<Menu?>> Handle(GetMenuQuery request, CancellationToken cancellationToken)
    {
        var menu = await _menuRepository.GetByIdAsync(request.MenuId, cancellationToken);
        if (menu is null)
            return Error.NotFound(description: "菜单未找到");
        return menu;
    }
}
