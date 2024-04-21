
using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Infrastructure;

public class PermissionRepository : IPermissionRepository
{
    private readonly AppDbContext _dbContext;

    public PermissionRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Permission permission)
    {
        await _dbContext.Permissions.AddAsync(permission);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
