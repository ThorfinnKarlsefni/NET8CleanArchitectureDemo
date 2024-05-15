using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class MenuRepository(AppDbContext _dbContext) : IMenuRepository
{
    public async Task AddAsync(Menu menu, CancellationToken cancellationToken)
    {
        await _dbContext.Menus.AddAsync(menu, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> CheckControllerAsync(string Controller)
    {
        return await _dbContext.Menus.AnyAsync(x => x.Controller == Controller);
    }

    public async Task<List<Menu>> GetListMenuAsync(bool onlyVisible, CancellationToken cancellationToken)
    {
        IQueryable<Menu> query = _dbContext.Menus;

        if (onlyVisible)
        {
            query = query.Where(x => x.Visibility == true);
        }

        return await query
            .Where(x => x.DeletedAt == null)
            .ToListAsync(cancellationToken);
    }

    public async Task<Menu?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Menus
            .Where(x => x.Id == id && x.DeletedAt == null)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task UpdateAsync(Menu menu, CancellationToken cancellationToken)
    {
        _dbContext.Menus.Update(menu);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateRangeAsync(List<Menu> menus, CancellationToken cancellationToken)
    {
        _dbContext.Menus.UpdateRange(menus);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Menu>> GetPermissionMenuAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Menus
            .Where(x => x.Controller != string.Empty)
            .Where(x => x.Component != string.Empty)
            .Where(x => x.DeletedAt == null)
            .ToListAsync();
    }
}
