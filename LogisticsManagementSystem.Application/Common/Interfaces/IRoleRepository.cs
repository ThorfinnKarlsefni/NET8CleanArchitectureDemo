﻿using LogisticsManagementSystem.Domain;
using Microsoft.AspNetCore.Identity;

namespace LogisticsManagementSystem.Application;

public interface IRoleRepository
{
    Task<IdentityResult> CreateAsync(Role role);
    Task<IdentityResult> DeleteAsync(Role role);
    Task<Role?> FindByIdAsync(string roleId);
    Task<RoleListResult> GetRoleListAsync(int pageNumber, int pageSize, string? searchKeyword);
    Task<List<Role>?> GetAllRoleAsync();
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
