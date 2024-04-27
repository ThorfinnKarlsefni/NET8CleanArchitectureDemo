using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GetMenuTreeQueryHandler : IRequestHandler<GetMenuTreeQuery, ErrorOr<List<Menu>>>
{
    private readonly IMenuRepository _menuRepository;

    public GetMenuTreeQueryHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<List<Menu>>> Handle(GetMenuTreeQuery request, CancellationToken cancellationToken)
    {
        return await _menuRepository.GetMenuListAsync(cancellationToken);
    }
}
