using ErrorOr;
using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;

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

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
