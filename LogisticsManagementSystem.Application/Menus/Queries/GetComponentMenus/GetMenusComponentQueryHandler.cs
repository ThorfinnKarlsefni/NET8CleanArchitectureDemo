using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GetComponentMenusQueryHandler(IMenuRepository _menuRepository) : IRequestHandler<GetComponentMenusQuery, ErrorOr<List<Menu>>>
{
    public async Task<ErrorOr<List<Menu>>> Handle(GetComponentMenusQuery request, CancellationToken cancellationToken)
    {
        return await _menuRepository.GetComponentMenusAsync(cancellationToken);
    }
}

