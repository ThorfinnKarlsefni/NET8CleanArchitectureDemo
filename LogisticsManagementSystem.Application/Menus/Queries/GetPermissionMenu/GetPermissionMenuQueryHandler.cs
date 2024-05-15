using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GetPermissionMenuQueryHandler(IMenuRepository _menuRepository) : IRequestHandler<GetPermissionMenuQuery, ErrorOr<List<Menu>>>
{
    public async Task<ErrorOr<List<Menu>>> Handle(GetPermissionMenuQuery request, CancellationToken cancellationToken)
    {
        return await _menuRepository.GetPermissionMenuAsync(cancellationToken);
    }
}

