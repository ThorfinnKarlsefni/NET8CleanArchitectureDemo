using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class ListPermissionQueryHandler(IPermissionRepository _permissionRepository) : IRequestHandler<ListPermissionQuery, ErrorOr<List<Permission>>>
{
    public async Task<ErrorOr<List<Permission>>> Handle(ListPermissionQuery request, CancellationToken cancellationToken)
    {
        return await _permissionRepository.GetListPermissionsAsync(cancellationToken);
    }
}
