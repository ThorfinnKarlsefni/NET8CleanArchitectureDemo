using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface IRoleMenusRepository
{
    Task AddRangeAsync(List<RoleMenus> menuRole, CancellationToken cancellationToken);
    Task DeleteAsync(Guid roleId, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
