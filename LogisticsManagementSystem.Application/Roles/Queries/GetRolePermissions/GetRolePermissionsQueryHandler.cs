using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GetRolePermissionsQueryHandler(
    IRoleRepository _roleRepository
) : IRequestHandler<GetRolePermissionsQuery, ErrorOr<List<int>>>
{
    public async Task<ErrorOr<List<int>>> Handle(GetRolePermissionsQuery query, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.FindByIdAsync(query.RoleId, cancellationToken);
        if (role is null)
        {
            return Error.NotFound(description: "角色不存在");
        }
        return await _roleRepository.GetPermissionsByRoleIdAsync(query.RoleId, cancellationToken);
    }
}
