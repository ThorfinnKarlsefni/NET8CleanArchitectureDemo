using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface IRoleRepository
{
    Task CreateAsync(Role role, CancellationToken cancellationToken);
    Task DeleteAsync(Role role, CancellationToken cancellationToken);
    Task UpdateAsync(Role role, CancellationToken cancellationToken);
    Task<Role?> FindByIdAsync(Guid roleId, CancellationToken cancellationToken);
    Task<(List<Role>, long)> GetListRoleAsync(int pageNumber, int pageSize, string? searchKeyword, CancellationToken cancellationToken);
    Task<List<Role>> GetRolesAsync(CancellationToken cancellationToken);
}
