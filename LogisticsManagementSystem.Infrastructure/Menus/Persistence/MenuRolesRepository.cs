using ErrorOr;
using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class MenuRolesRepository : IMenuRolesRepository
{
    private readonly AppDbContext _dbContext;

    public MenuRolesRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddRangeAsync(List<MenuRole> menuRole, CancellationToken cancellationToken)
    {
        await _dbContext.AddRangeAsync(menuRole, cancellationToken);
    }

    public async Task DeleteAsync(Guid roleId, CancellationToken cancellationToken)
    {
        await _dbContext.MenuRoles.Where(x => x.RoleId == roleId).ExecuteDeleteAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
