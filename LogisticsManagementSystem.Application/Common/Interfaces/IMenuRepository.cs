using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface IMenuRepository
{
    Task AddAsync(Menu menu);
    Task<Menu?> GetByIdAsync(int id);
    Task DeleteAsync(Menu menu);
    Task<List<Menu>?> ListByRoleAsync();
    Task SaveChangesAsync();
}
