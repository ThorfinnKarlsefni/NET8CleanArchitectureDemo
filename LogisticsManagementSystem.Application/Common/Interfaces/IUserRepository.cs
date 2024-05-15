using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface IUserRepository
{
    Task<User?> FindByNameAsync(string username, CancellationToken cancellationToken);
    Task<List<string>> GetRolesAsync(User user, CancellationToken cancellationToken);
    Task CreateAsync(User user, CancellationToken CancellationToken);
    Task<bool> IsExistsAsync(string username);
    Task<User?> FindByIdAsync(Guid userId, CancellationToken cancellationToken);
    Task<(List<User>, long)> GetListUserAsync(int pageNumber, int pageSize, string? searchKeyword, bool? Disable, CancellationToken cancellationToken);
    Task UpdateAsync(User user, CancellationToken cancellationToken);
    string EncryptPassword(string password);
    string GenerateSecurityStamp();
    bool CheckPassword(string hashedPassword, string providedPassword);
    bool CheckSecurityStampAsync(Guid userId, string securityStamp);
}