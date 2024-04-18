using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class MenuRepository : IMenuRepository
{
    private readonly AppDbContext _context;

    public MenuRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Menu menu)
    {
        await _context.Menus.AddAsync(menu);
    }

    public async Task<List<Menu>> GetAllMenuListAsync()
    {
        return await _context.Menus
            .Where(x => x.DeletedAt == null)
            .ToListAsync();
    }

    public async Task<Menu?> GetByIdAsync(int id)
    {
        return await _context.Menus.Where(x => x.Id == id && x.DeletedAt == null).FirstOrDefaultAsync();
    }

    public async Task<List<Menu>> GetMenuListAsync()
    {
        return await _context.Menus
            .Where(x => x.DeletedAt == null)
            .Where(x => x.Visibility == false)
            .ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
