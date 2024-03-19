using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;
    private readonly AppDbContext _dbContext;

    public UserRepository(UserManager<User> userManager, AppDbContext dbContext)
    {
        _userManager = userManager;
        _dbContext = dbContext;
    }

    public async Task<IdentityResult> CreateAsync(User user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<bool> UserExistsAsync(string username)
    {
        return !await _userManager.Users.AnyAsync(u => string.Equals(u.NormalizedUserName, username.ToUpper()));
    }

    public async Task<User?> FindByNameAsync(string username)
    {
        return await _userManager.FindByNameAsync(username);
    }

    public async Task<bool> CheckPasswordAsync(User user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<IList<string>> GetRolesAsync(User user)
    {
        return await _userManager.GetRolesAsync(user);
    }

    public async Task<User?> FindByIdAsync(string userId)
    {
        return await _userManager.Users
            .Where(u => u.Id == Guid.Parse(userId))
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .Include(u => u.Company)
            .FirstOrDefaultAsync();
    }

    public async Task<ListUserResult?> GetListUserAsync(int pageNumber, int pageSize, string? searchKeyword, bool? Disable)
    {
        IQueryable<User> query = _userManager.Users;

        if (Disable == true)
        {
            query = query.Where(u => u.DeletedAt != null);
        }
        else
        {
            query = query.Where(u => u.DeletedAt == null);
        }

        if (!string.IsNullOrWhiteSpace(searchKeyword))
        {
            var keyword = searchKeyword.Trim();
            query = query.Where(u => u.UserName!.Contains(keyword) || u.Name.Contains(keyword));
        }

        var users = await query
            .OrderBy(u => u.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(u => new ListUser(
                u.Id,
                u.UserName,
                u.Name,
                u.Avatar,
                u.CreatedAt,
                u.UserRoles.Select(ur => new ListUserRoleResult(ur.RoleId, ur.Role.Name))))
            .ToListAsync();

        var totalCount = await query.LongCountAsync();

        return new ListUserResult(
            totalCount,
            pageNumber,
            pageSize,
            users);
    }

    public async Task<bool> IsInAdminAsync(User user)
    {
        return await _userManager.IsInRoleAsync(user, "admin");
    }

    public async Task<IdentityResult> ResetUserPasswordAsync(User user, string password)
    {
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        return await _userManager.ResetPasswordAsync(user, token, password);
    }

    public async Task<IdentityResult> UpdateAsync(User user)
    {
        return await _userManager.UpdateAsync(user);
    }

    public async Task<int> SaveChangeAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}
