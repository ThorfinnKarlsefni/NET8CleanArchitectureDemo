using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class RoleRepository : IRoleRepository
{
    private readonly RoleManager<Role> _roleManager;

    public RoleRepository(RoleManager<Role> roleManager)
    {
        _roleManager = roleManager;
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

    public async Task<ListRoleResult> GetListRoleAsync(int pageNumber, int pageSize, string? searchKeyword)
    {
        IQueryable<Role> query = _roleManager.Roles;

        if (!string.IsNullOrWhiteSpace(searchKeyword))
        {
            var keyword = searchKeyword.Trim();
            query = query.Where(r => r.NormalizedName!.Contains(keyword.ToUpper()));
        }

        var roles = await query
            .Where(r => r.DeletedAt == null)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(r => new ListRole(
                r.Id,
                r.Name,
                r.NormalizedName,
                r.CreatedAt
            ))
            .ToListAsync();
        var totalCount = await query.LongCountAsync();
        return new ListRoleResult(
            totalCount,
            pageNumber,
            pageSize,
            roles
        );
    }
}
