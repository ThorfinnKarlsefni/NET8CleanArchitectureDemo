using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface IRoleMenusRepository
{
    Task AddRangeAsync(List<RoleMenus> menuRole, CancellationToken cancellationToken);
    Task ExecuteDeleteAsync(Guid roleId, CancellationToken cancellationToken);
}
