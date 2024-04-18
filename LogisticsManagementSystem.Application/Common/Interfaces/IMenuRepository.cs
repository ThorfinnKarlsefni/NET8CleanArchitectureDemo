using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface IMenuRepository
{
    Task AddAsync(Menu menu);
    Task<Menu?> GetByIdAsync(int id);
    Task<List<Menu>> GetMenuListAsync();
    Task<List<Menu>> GetAllMenuListAsync();
    Task SaveChangesAsync();
}
