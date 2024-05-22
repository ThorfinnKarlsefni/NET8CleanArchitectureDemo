using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class ListMenusQueryHandler(IMenuRepository _menuRepository) : IRequestHandler<ListMenusQuery, ErrorOr<List<Menu>>>
{
    public async Task<ErrorOr<List<Menu>>> Handle(ListMenusQuery request, CancellationToken cancellationToken)
    {
        return await _menuRepository.GetListMenuAsync(cancellationToken);
    }
}
