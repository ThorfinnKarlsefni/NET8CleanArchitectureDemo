using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class RoleRepository(AppDbContext _dbContext) : IRoleRepository
{
    public async Task CreateAsync(Role role, CancellationToken cancellationToken)
    {
        await _dbContext.Roles.AddAsync(role);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Role role, CancellationToken cancellationToken)
    {
        _dbContext.Roles.Update(role);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Role role, CancellationToken cancellationToken)
    {
        _dbContext.Roles.Update(role);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Role?> FindByIdAsync(Guid roleId, CancellationToken cancellationToken)
    {
        return await _dbContext.Roles
            .Where(x => x.Id == roleId && x.DeletedAt == null)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<Role>> GetRolesAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Roles
            .Where(x => x.NormalizedName != "ADMIN")
            .Where(x => x.DeletedAt == null)
            .ToListAsync(cancellationToken);
    }

    public async Task<(List<Role>, long)> GetListRoleAsync(int pageNumber, int pageSize, string? searchKeyword, CancellationToken cancellationToken)
    {
        IQueryable<Role> query = _dbContext.Roles;

        if (!string.IsNullOrWhiteSpace(searchKeyword))
        {
            var keyword = searchKeyword.Trim();
            query = query.Where(r => r.NormalizedName!.Contains(keyword.ToUpper()));
        }

        var roles = await query
            .Include(r => r.RoleMenus)
                .ThenInclude(r => r.Menu)
            .Include(r => r.RolePermissions)
                .ThenInclude(r => r.Permission)
            .Where(r => r.DeletedAt == null)
            .Where(r => r.NormalizedName != "ADMIN")
            .OrderBy(r => r.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var totalCount = await query.LongCountAsync();

        return (roles, totalCount);
    }

    public async Task<List<int>> GetPermissionsByRoleIdAsync(Guid roleId, CancellationToken cancellationToken)
    {
        return await _dbContext.Roles
            .Where(x => x.Id == roleId)
                .Include(x => x.RolePermissions)
            .SelectMany(x => x.RolePermissions.Select(x => x.PermissionId))
            .ToListAsync(cancellationToken);
    }
}
