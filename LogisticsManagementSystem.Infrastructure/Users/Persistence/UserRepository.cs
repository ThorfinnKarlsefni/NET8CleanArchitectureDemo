using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
        return !await _userManager.Users.AnyAsync(u => u.UserName == username);
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
        return await _userManager.FindByIdAsync(userId);
    }

    public async Task<List<ListUserResponse>?> GetListUserAsync()
    {
        return await _userManager.Users
            .Where(u => u.DeletedAt == null)
            .Select(u => new ListUserResponse
            {
                Name = u.Name,
                Avatar = u.Avatar,
                CreatedAt = u.CreatedAt,
                Roles = u.UserRoles.Select(ur => ur.Role != null ? ur.Role.Name : "Unknown").ToList()
            })
            .ToListAsync();
    }
}
