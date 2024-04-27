using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GetMenuAllTreeQueryHandler : IRequestHandler<GetMenuAllTreeQuery, ErrorOr<List<Menu>>>
{
    private readonly IMenuRepository _menuRepository;

    public GetMenuAllTreeQueryHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<List<Menu>>> Handle(GetMenuAllTreeQuery request, CancellationToken cancellationToken)
    {
        return await _menuRepository.GetAllMenuListAsync(cancellationToken);
    }
}
