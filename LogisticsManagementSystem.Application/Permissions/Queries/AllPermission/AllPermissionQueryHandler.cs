using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class AllPermissionQueryHandler : IRequestHandler<AllPermissionQuery, ErrorOr<List<Permission>>>
{
    private readonly IPermissionRepository _permissionRepository;

    public AllPermissionQueryHandler(IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public async Task<ErrorOr<List<Permission>>> Handle(AllPermissionQuery request, CancellationToken cancellationToken)
    {
        var permissions = await _permissionRepository.GetAllAsync();
        return permissions;
    }
}
