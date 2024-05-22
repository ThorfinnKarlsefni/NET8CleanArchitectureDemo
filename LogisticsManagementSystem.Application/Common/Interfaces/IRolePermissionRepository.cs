using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface IRolePermissionRepository
{
    Task<RolePermissions?> GetPermissionsByPermissionIdAsync(int permissionId, CancellationToken cancellationToken);

    Task<List<RolePermissions>> GetPermissionsByRoleIdAsync(Guid roleId, CancellationToken cancellationToken);
    Task DeleteRangeAsync(List<RolePermissions> rolePermissions, CancellationToken cancellationToken);

    Task CreateRangeAsync(List<RolePermissions> rolePermissions, CancellationToken cancellationToken);
}
