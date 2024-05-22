using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class RolePermissionsRepository(AppDbContext _dbContext) : IRolePermissionRepository
{
    public async Task CreateRangeAsync(List<RolePermissions> rolePermissions, CancellationToken cancellationToken)
    {
        await _dbContext.RolePermissions
            .AddRangeAsync(rolePermissions, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteRangeAsync(List<RolePermissions> rolePermissions, CancellationToken cancellationToken)
    {
        _dbContext.RolePermissions.RemoveRange(rolePermissions);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<RolePermissions?> GetPermissionsByPermissionIdAsync(int permissionId, CancellationToken cancellationToken)
    {
        return await _dbContext.RolePermissions
            .Where(x => x.PermissionId == permissionId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<RolePermissions>> GetPermissionsByRoleIdAsync(Guid roleId, CancellationToken cancellationToken)
    {
        return await _dbContext.RolePermissions
            .Where(x => x.RoleId == roleId)
            .ToListAsync();
    }

}
