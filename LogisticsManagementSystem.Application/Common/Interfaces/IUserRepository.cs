using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface IUserRepository
{
    Task<User?> FindByNameAsync(string username, CancellationToken cancellationToken);
    // Task<bool> CheckPasswordAsync(User user, string password);
    Task<List<string>> GetRolesAsync(User user, CancellationToken cancellationToken);
    Task CreateAsync(User user, CancellationToken CancellationToken);
    Task<bool> UserExistsAsync(string username);
    Task<User?> FindByIdAsync(string userId, CancellationToken cancellationToken);
    Task<UserListResult?> GetUserListAsync(int pageNumber, int pageSize, string? searchKeyword, bool? Disable, CancellationToken cancellationToken);
    // Task<bool> IsInAdminAsync(User user);
    // Task ResetUserPasswordAsync(User user, string password);
    Task UpdateAsync(User user, CancellationToken cancellationToken);
}
