using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class RolePermissionsRepository(AppDbContext _dbContext) : IRolePermissionRepository
{
    public async Task<RolePermissions?> GetPermissionByPermissionIdAsync(int permissionId, CancellationToken cancellationToken)
    {
        return await _dbContext.RolePermissions
            .Where(x => x.PermissionId == permissionId)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
