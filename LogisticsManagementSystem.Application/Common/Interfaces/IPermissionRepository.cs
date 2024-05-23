using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface IPermissionRepository
{
    Task<List<Permission>> GetListPermissionsAsync(CancellationToken cancellationToken);
    Task<bool> IsExistAsync(string controller, string method, CancellationToken cancellationToken);
    Task<Permission?> GetByIdAsync(int permissionId, CancellationToken cancellationToken);
    Task AddAsync(Permission permission, CancellationToken cancellationToken);
    Task UpdateAsync(Permission permission, CancellationToken cancellationToken);
    Task UpdateRangeAsync(List<Permission> permissions, CancellationToken cancellationToken);
    Task DeleteAsync(Permission permission, CancellationToken cancellationToken);
}
