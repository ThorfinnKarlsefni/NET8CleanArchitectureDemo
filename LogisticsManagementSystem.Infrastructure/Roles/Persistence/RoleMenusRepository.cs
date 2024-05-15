using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class RoleMenusRepository(AppDbContext _dbContext) : IRoleMenusRepository
{
    public async Task AddRangeAsync(List<RoleMenus> menuRole, CancellationToken cancellationToken)
    {
        await _dbContext.RoleMenus.AddRangeAsync(menuRole, cancellationToken);
    }

    public async Task DeleteAsync(Guid roleId, CancellationToken cancellationToken)
    {
        await _dbContext.RoleMenus
            .Where(x => x.RoleId == roleId)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
