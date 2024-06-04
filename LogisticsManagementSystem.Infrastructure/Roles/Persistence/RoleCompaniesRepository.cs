using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class RoleCompaniesRepository(
    AppDbContext _dbContext
) : IRoleCompaniesRepository
{
    public async Task AddRangeAsync(List<RoleCompanies> roleCompanies, CancellationToken cancellationToken)
    {
        await _dbContext.RoleCompanies
            .AddRangeAsync(roleCompanies, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteRangeAsync(Guid roleId, CancellationToken cancellationToken)
    {
        await _dbContext.RoleCompanies
            .Where(x => x.RoleId == roleId)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<List<RoleCompanies>> GetListByRoleIdAsync(Guid roleId, CancellationToken cancellationToken)
    {
        return await _dbContext.RoleCompanies
            .Where(x => x.RoleId == roleId)
            .Include(x => x.Company)
            .ToListAsync(cancellationToken);
    }
}
