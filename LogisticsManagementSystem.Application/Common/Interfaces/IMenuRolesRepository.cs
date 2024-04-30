
using ErrorOr;
using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface IMenuRolesRepository
{
    Task AddRangeAsync(List<MenuRole> menuRole, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
