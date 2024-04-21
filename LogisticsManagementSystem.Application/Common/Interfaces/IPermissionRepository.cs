using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface IPermissionRepository
{
    Task AddAsync(Permission permission);
    Task SaveChangesAsync();
}
