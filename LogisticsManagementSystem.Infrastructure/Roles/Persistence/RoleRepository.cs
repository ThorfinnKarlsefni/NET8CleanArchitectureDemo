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
        _dbContext.Roles.Remove(role);
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

    public async Task<List<Role>> GetAllRoleAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Roles
            .Where(x => x.DeletedAt == null)
            .ToListAsync(cancellationToken);
    }

    public async Task<RoleListResult> GetRoleListAsync(int pageNumber, int pageSize, string? searchKeyword, CancellationToken cancellationToken)
    {
        IQueryable<Role> query = _dbContext.Roles;

        if (!string.IsNullOrWhiteSpace(searchKeyword))
        {
            var keyword = searchKeyword.Trim();
            query = query.Where(r => r.NormalizedName!.Contains(keyword.ToUpper()));
        }

        var roles = await query
            .Include(r => r.MenuRoles)
            .ThenInclude(r => r.Menu)
            .Where(r => r.DeletedAt == null)
            .Where(r => r.NormalizedName != "ADMIN")
            .OrderBy(r => r.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(r => new RoleList(
                r.Id,
                r.Name,
                r.NormalizedName,
                r.CreatedAt,
                r.MenuRoles.Select(ur => ur.Menu.Id).ToList()
            ))
            .ToListAsync(cancellationToken);

        var totalCount = await query.LongCountAsync();
        return new RoleListResult(
            totalCount,
            pageNumber,
            pageSize,
            roles
        );
    }


}
