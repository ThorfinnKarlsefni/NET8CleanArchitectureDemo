using LogisticsManagementSystem.Domain;
using Microsoft.AspNetCore.Identity;

namespace LogisticsManagementSystem.Application;

public interface IUserRepository
{
    Task<User?> FindByNameAsync(string username);
    Task<bool> CheckPasswordAsync(User user, string password);
    Task<IList<string>> GetRolesAsync(User user);
    Task<IdentityResult> CreateAsync(User user, string password);
    Task<bool> UserExistsAsync(string username);
    Task<User?> FindByIdAsync(string userId);
    Task<ListUserResult?> GetListUserAsync(int pageNumber, int pageSize, string? searchKeyword, bool? Disable);
    Task<bool> IsInAdminAsync(User user);
    Task<IdentityResult> ResetUserPasswordAsync(User user, string password);
    Task<IdentityResult> UpdateAsync(User user);
    Task<int> SaveChangeAsync();
}
