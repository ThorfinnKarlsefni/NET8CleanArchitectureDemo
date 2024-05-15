using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GetMenusQueryHandler(IMenuRepository _menuRepository) : IRequestHandler<GetMenusQuery, ErrorOr<List<Menu>>>
{
    public async Task<ErrorOr<List<Menu>>> Handle(GetMenusQuery request, CancellationToken cancellationToken)
    {
        return await _menuRepository.GetListMenuAsync(onlyVisible: true, cancellationToken);
    }
}
