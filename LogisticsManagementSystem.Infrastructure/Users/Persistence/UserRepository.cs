using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class UserRepository(AppDbContext _dbContext) : IUserRepository
{
    public async Task CreateAsync(User user, CancellationToken cancellationToken)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> UserExistsAsync(string username)
    {
        return !await _dbContext.Users.AnyAsync(u => string.Equals(u.UserName, username.Trim()));
    }

    public async Task<User?> FindByNameAsync(string username, CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .Where(x => x.UserName == username.Trim())
            .FirstOrDefaultAsync(cancellationToken);
    }

    // public async Task<bool> CheckPasswordAsync(User user, string password)
    // {

    // }

    public async Task<List<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .Where(u => u.Id == user.Id)
            .SelectMany(u => u.UserRoles)
            .Select(ur => ur.Role.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task<User?> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .Where(u => u.Id == Guid.Parse(userId))
            .Include(ur => ur.UserRoles)
            .ThenInclude(r => r.Role)
            .Include(u => u.Company)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<UserListResult?> GetUserListAsync(int pageNumber, int pageSize, string? searchKeyword, bool? Disable, CancellationToken cancellationToken)
    {
        IQueryable<User> query = _dbContext.Users;

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
            .Select(u => new UserList(
                u.Id,
                u.UserName,
                u.Name,
                u.Avatar,
                u.PhoneNumber,
                u.CreatedAt,
                u.UserRoles.Select(x => new UserListRoleResult(x.Role.Id, x.Role.Name))))
            .ToListAsync(cancellationToken);

        var totalCount = await query.LongCountAsync();

        return new UserListResult(
            totalCount,
            pageNumber,
            pageSize,
            users);
    }

    // public async Task<bool> IsInAdminAsync(User user)
    // {
    //     return await _userManager.IsInRoleAsync(user, "admin");
    // }

    // public async Task ResetUserPasswordAsync(User user, string password)
    // {
    //     var token = await _userManager.GeneratePasswordResetTokenAsync(user);
    //     return await _userManager.ResetPasswordAsync(user, token, password);
    // }

    public async Task UpdateAsync(User user, CancellationToken cancellationToken)
    {
        _dbContext.Update(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

}
