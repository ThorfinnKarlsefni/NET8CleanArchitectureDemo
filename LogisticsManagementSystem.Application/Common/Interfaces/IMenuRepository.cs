using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface IMenuRepository
{
    Task AddAsync(Menu menu, CancellationToken cancellationToken);
    Task<Menu?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<Menu>> GetListMenuAsync(bool onlyVisible, CancellationToken cancellationToken);
    Task<List<Menu>> GetPermissionMenuAsync(CancellationToken cancellationToken);
    Task UpdateAsync(Menu menu, CancellationToken cancellationToken);
    Task UpdateRangeAsync(List<Menu> menus, CancellationToken cancellationToken);
    Task<bool> CheckControllerAsync(string Controller);
}
