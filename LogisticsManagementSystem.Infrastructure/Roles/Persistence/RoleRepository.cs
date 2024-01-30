using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.AspNetCore.Identity;

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
}
