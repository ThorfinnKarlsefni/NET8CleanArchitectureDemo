using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class ListMenusQueryHandler : IRequestHandler<ListMenusQuery, ErrorOr<List<Menu>?>>
{
    private readonly IMenuRepository _menuRepository;

    public ListMenusQueryHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<List<Menu>?>> Handle(ListMenusQuery request, CancellationToken cancellationToken)
    {
        return await _menuRepository.ListByRoleAsync();
    }
}
