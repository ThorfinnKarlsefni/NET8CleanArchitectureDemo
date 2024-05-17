
using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class PermissionRepository(AppDbContext _dbContext) : IPermissionRepository
{
    public async Task AddAsync(Permission permission, CancellationToken cancellationToken)
    {
        await _dbContext.Permissions.AddAsync(permission, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    // public async Task DeleteAsync(Permission permission)
    // {
    //     _dbContext.Permissions.Update(permission);
    //     await _dbContext.SaveChangesAsync();
    // }

    public async Task<List<Permission>> GetListPermissionsAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Permissions
            .Where(x => x.DeletedAt == null)
            .OrderBy(x => x.Sort)
            .ToListAsync(cancellationToken);
    }

    public async Task<Permission?> GetByIdAsync(int permissionId, CancellationToken cancellationToken)
    {
        return await _dbContext.Permissions
            .Where(x => x.Id == permissionId && x.DeletedAt == null)
            .FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(Permission permission, CancellationToken cancellationToken)
    {
        _dbContext.Permissions.Update(permission);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateRangeAsync(List<Permission> permissions, CancellationToken cancellationToken)
    {
        _dbContext.Permissions.UpdateRange(permissions);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> IsExistAsync(string controller, string method, CancellationToken cancellationToken)
    {
        return await _dbContext.Permissions
            .AnyAsync(
                x => x.Controller == controller.Trim() &&
                x.Method == method.Trim() && x.DeletedAt == null
            );
    }
}
