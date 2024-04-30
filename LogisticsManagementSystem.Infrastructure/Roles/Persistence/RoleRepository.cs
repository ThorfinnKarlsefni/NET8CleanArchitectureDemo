using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class RoleRepository : IRoleRepository
{
    private readonly RoleManager<Role> _roleManager;
    private readonly AppDbContext _dbContext;

    public RoleRepository(RoleManager<Role> roleManager, AppDbContext dbContext)
    {
        _roleManager = roleManager;
        _dbContext = dbContext;
    }

    public async Task<IdentityResult> CreateAsync(Role role)
    {
        return await _roleManager.CreateAsync(role);
    }

    public async Task<IdentityResult> DeleteAsync(Role role)
    {
        return await _roleManager.DeleteAsync(role);
    }

    public async Task<Role?> FindByIdAsync(string roleId)
    {
        return await _roleManager.FindByIdAsync(roleId);
    }

    public async Task<List<Role>?> GetAllRoleAsync()
    {
        return await _roleManager.Roles.Where(r => r.DeletedAt == null).ToListAsync();
    }

    public async Task<RoleListResult> GetRoleListAsync(int pageNumber, int pageSize, string? searchKeyword)
    {
        IQueryable<Role> query = _roleManager.Roles;

        if (!string.IsNullOrWhiteSpace(searchKeyword))
        {
            var keyword = searchKeyword.Trim();
            query = query.Where(r => r.NormalizedName!.Contains(keyword.ToUpper()));
        }

        var roles = await query
            .Where(r => r.DeletedAt == null)
            .Where(r => r.NormalizedName != "ADMIN")
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(r => new RoleList(
                r.Id,
                r.Name,
                r.NormalizedName,
                r.CreatedAt
            // r.
            // r.Menus.Select(menu => new
            // {
            //     Id = menu.MenuId,
            //     name = menu.MenuId
            // })
            ))
            .ToListAsync();

        var totalCount = await query.LongCountAsync();
        return new RoleListResult(
            totalCount,
            pageNumber,
            pageSize,
            roles
        );
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
