using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface IRolePermissionRepository
{
    Task<RolePermissions?> GetPermissionByPermissionIdAsync(int permissionId, CancellationToken cancellationToken);
}
