using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface IPermissionRepository
{
    Task<List<Permission>> GetAllAsync();
    Task<Permission?> GetByIdAsync(int id);
    Task AddAsync(Permission permission, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
