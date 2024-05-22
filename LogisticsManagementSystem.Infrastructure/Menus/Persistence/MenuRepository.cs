using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class MenuRepository(AppDbContext _dbContext) : IMenuRepository
{
    public async Task CreateAsync(Menu menu, CancellationToken cancellationToken)
    {
        await _dbContext.Menus.AddAsync(menu, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
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

    public async Task<bool> IsMenuControllerExists(string Controller)
    {
        return await _dbContext.Menus.AnyAsync(x => string.Equals(x.Controller, Controller.Trim()));
    }

    public async Task<List<Menu>> GetComponentMenusAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Menus
            .Where(x => x.Controller != string.Empty)
            .Where(x => x.Component != string.Empty)
            .Where(x => x.DeletedAt == null)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Menu>> GetListMenuAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Menus
            .Where(x => x.DeletedAt == null)
            .ToListAsync(cancellationToken);
    }

    public async Task<Menu?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Menus
            .Where(x => x.Id == id && x.DeletedAt == null)
            .FirstOrDefaultAsync(cancellationToken);
    }


    public async Task<List<Menu>> GetMenusByRoleIdAsync(Guid roleId, bool isAdmin, CancellationToken cancellationToken)
    {
        var allMenus = await _dbContext.Menus
            .Where(x => x.DeletedAt == null)
            .Include(x => x.RoleMenus)
            .ToListAsync(cancellationToken);

        if (isAdmin)
        {
            return allMenus;
        }

        var roleMenus = allMenus
            .Where(x => x.RoleMenus.Any(rm => rm.RoleId == roleId))
            .Where(x => x.Controller != "Menu" || x.Controller != "Permission")
            .ToList();

        // 使用 Dictionary 以提高查找父节点的效率
        var menuDictionary = allMenus.ToDictionary(m => m.Id);
        var parentIds = new HashSet<int?>();

        foreach (var menu in roleMenus)
        {
            var parentId = menu.ParentId;
            while (parentId != null && !parentIds.Contains(parentId))
            {
                parentIds.Add(parentId);
                parentId = menuDictionary.ContainsKey(parentId.Value) ? menuDictionary[parentId.Value].ParentId : null;
            }
        }

        // 将父节点添加到结果中
        var result = roleMenus.Concat(allMenus.Where(x => parentIds.Contains(x.Id))).Distinct().ToList();

        return result;
    }

}
