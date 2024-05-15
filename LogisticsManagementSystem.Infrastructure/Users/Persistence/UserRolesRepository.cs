using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Infrastructure;

public class UserRolesRepository(AppDbContext _dbContext) : IUserRolesRepository
{
    public async Task AddAsync(UserRole userRole, CancellationToken cancellationToken)
    {
        await _dbContext.UserRoles.AddAsync(userRole, cancellationToken);
        await _dbContext.SaveChangesAsync();
    }
}
