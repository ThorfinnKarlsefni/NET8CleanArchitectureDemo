using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class UserRolesRepository(AppDbContext _dbContext) : IUserRolesRepository
{
    public async Task AddAsync(UserRole userRole, CancellationToken cancellationToken)
    {
        await _dbContext.UserRoles.AddAsync(userRole, cancellationToken);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(UserRole userRole, CancellationToken cancellationToken)
    {
        _dbContext.UserRoles.Remove(userRole);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<UserRole>> GetListByRoleIdAsync(Guid roleId, CancellationToken cancellation)
    {
        return await _dbContext.UserRoles
            .Where(x => x.RoleId == roleId)
            .ToListAsync();
    }

    public async Task<UserRole?> GetUserRoleByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _dbContext.UserRoles
            .Where(x => x.UserId == userId)
            .FirstOrDefaultAsync();
    }
}
