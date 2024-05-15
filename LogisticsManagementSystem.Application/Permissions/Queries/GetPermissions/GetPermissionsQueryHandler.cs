using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GetPermissionsQueryHandler(IPermissionRepository _permissionRepository) : IRequestHandler<GetPermissionsQuery, ErrorOr<List<Permission>>>
{
    public async Task<ErrorOr<List<Permission>>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
    {
        return await _permissionRepository.GetPermissionsAsync(cancellationToken);
    }
}
