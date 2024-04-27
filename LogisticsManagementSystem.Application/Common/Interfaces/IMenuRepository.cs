using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface IMenuRepository
{
    Task AddAsync(Menu menu, CancellationToken cancellationToken);
    Task<Menu?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<Menu>> GetMenuListAsync(CancellationToken cancellationToken);
    Task<List<Menu>> GetAllMenuListAsync(CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
