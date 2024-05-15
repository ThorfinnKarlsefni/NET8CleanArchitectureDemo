using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface IUserRolesRepository
{
    Task AddAsync(UserRole userRole, CancellationToken cancellationToken);
}
