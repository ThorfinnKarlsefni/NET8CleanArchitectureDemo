using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class MenuRepository : IMenuRepository
{
    private readonly AppDbContext _context;

    public MenuRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Menu menu, CancellationToken cancellationToken)
    {
        await _context.Menus.AddAsync(menu, cancellationToken);
    }

    public async Task<List<Menu>> GetAllMenuListAsync(CancellationToken cancellationToken)
    {
        return await _context.Menus
            .Where(x => x.DeletedAt == null)
            .ToListAsync(cancellationToken);
    }

    public async Task<Menu?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Menus.Where(x => x.Id == id && x.DeletedAt == null).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<Menu>> GetMenuListAsync(CancellationToken cancellationToken)
    {
        return await _context.Menus
            .Where(x => x.DeletedAt == null)
            .Where(x => x.Visibility == true)
            .ToListAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
