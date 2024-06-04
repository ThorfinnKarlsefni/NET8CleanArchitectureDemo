using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface IRoleCompaniesRepository
{
    Task AddRangeAsync(List<RoleCompanies> roleCompanies, CancellationToken cancellationToken);
    Task<List<RoleCompanies>> GetListByRoleIdAsync(Guid roleId, CancellationToken cancellationToken);
    Task DeleteRangeAsync(Guid roleId, CancellationToken cancellationToken);
}
