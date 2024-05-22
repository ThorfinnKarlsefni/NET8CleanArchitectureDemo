using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface IUserRolesRepository
{
    Task AddAsync(UserRole userRole, CancellationToken cancellationToken);
    Task DeleteAsync(UserRole userRole, CancellationToken cancellationToken);
    Task<List<UserRole>> GetListByRoleIdAsync(Guid roleId, CancellationToken cancellation);
    Task<UserRole?> GetUserRoleByUserIdAsync(Guid userId, CancellationToken cancellationToken);
}
