using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LogisticsManagementSystem.Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;

    public UserRepository(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> CreateAsync(User user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<bool> UserExistsAsync(string username)
    {
        return !await _userManager.Users.AnyAsync(u => u.NormalizedUserName == username.ToUpper());
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

    public async Task<ListUserResult?> GetListUserAsync(int pageNumber, int pageSize, string? searchKeyword)
    {

        var totalCount = await GetUserTotalCount(searchKeyword);

        IQueryable<User> query = _userManager.Users
        .Where(u => u.DeletedAt == null);

        if (!string.IsNullOrEmpty(searchKeyword))
        {
            var keyword = searchKeyword.Trim();
            query = query.Where(u => u.UserName!.Contains(keyword) || u.Name.Contains(keyword));
        }

        var users = await query
            .OrderBy(u => u.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(u => new UserList(
                u.Id,
                u.UserName,
                u.Name,
                u.Avatar,
                u.CreatedAt,
                u.UserRoles.Select(ur => new ListUserRoleResult(ur.RoleId, ur.Role.Name))))
            .ToListAsync();

        return new ListUserResult(
            totalCount,
            pageSize,
            pageNumber,
            users
        );
    }

    private async Task<int> GetUserTotalCount(string? searchKeyword)
    {
        if (!string.IsNullOrEmpty(searchKeyword))
            return await _userManager.Users.Where(u => u.UserName!.Contains(searchKeyword.Trim()) || u.Name.Contains(searchKeyword.Trim())).CountAsync();

        return await _userManager.Users.Where(u => u.DeletedAt == null).CountAsync();
    }
}
