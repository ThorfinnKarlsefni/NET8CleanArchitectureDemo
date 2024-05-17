using System.Globalization;
using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class RoleMenusRepository(AppDbContext _dbContext) : IRoleMenusRepository
{
    public async Task AddRangeAsync(List<RoleMenus> menuRole, CancellationToken cancellationToken)
    {
        await _dbContext.RoleMenus.AddRangeAsync(menuRole, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task ExecuteDeleteAsync(Guid roleId, CancellationToken cancellationToken)
    {
        await _dbContext.RoleMenus
            .Where(x => x.RoleId == roleId)
            .ExecuteDeleteAsync(cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
