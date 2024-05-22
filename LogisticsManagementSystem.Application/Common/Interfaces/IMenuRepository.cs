using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface IMenuRepository
{
    Task<Menu?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<Menu>> GetListMenuAsync(CancellationToken cancellationToken);
    Task<List<Menu>> GetMenusByRoleIdAsync(Guid roleId, bool IsAdmin, CancellationToken cancellationToken);
    Task<List<Menu>> GetComponentMenusAsync(CancellationToken cancellationToken);
    Task CreateAsync(Menu menu, CancellationToken cancellationToken);
    Task UpdateAsync(Menu menu, CancellationToken cancellationToken);
    Task UpdateRangeAsync(List<Menu> menus, CancellationToken cancellationToken);
    Task<bool> IsMenuControllerExists(string Controller);
}
