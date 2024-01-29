using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface IRoleRepository
{
    Task<List<Role>> GetRolesAsync(string userId);
}
