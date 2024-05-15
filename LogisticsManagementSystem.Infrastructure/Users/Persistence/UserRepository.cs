using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class UserRepository(AppDbContext _dbContext, IPasswordEncryption _passwordEncryption) : IUserRepository
{
    public async Task CreateAsync(User user, CancellationToken cancellationToken)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> IsExistsAsync(string username)
    {
        return await _dbContext.Users.AnyAsync(u => string.Equals(u.NormalizedUserName, username));
    }

    public async Task<User?> FindByNameAsync(string username, CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .Where(x => x.NormalizedUserName == username.Trim().ToUpper())
            .Where(x => x.DeletedAt == null)
            .Include(ur => ur.UserRoles)
            .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .Where(u => u.Id == user.Id)
            .SelectMany(u => u.UserRoles)
            .Select(ur => ur.Role.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task<User?> FindByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .Where(u => u.Id == userId)
            .Include(ur => ur.UserRoles)
            .ThenInclude(r => r.Role)
            .Include(u => u.Company)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<(List<User>, long)> GetListUserAsync(int pageNumber, int pageSize, string? searchKeyword, bool? Disable, CancellationToken cancellationToken)
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
            .Where(u => !u.UserRoles.Any(x => x.Role.NormalizedName == "ADMIN"))
            .Include(ur => ur.UserRoles)
            .ThenInclude(x => x.Role)
            .Include(x => x.Company)
            .OrderBy(u => u.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var totalCount = await query.LongCountAsync();
        return (users, totalCount);
    }

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

    public bool CheckPassword(string hashedPassword, string providedPassword)
    {
        return _passwordEncryption.VerifyHashedPassword(hashedPassword, providedPassword);
    }

    public string EncryptPassword(string password)
    {
        return _passwordEncryption.HashPassword(password);
    }

    public string GenerateSecurityStamp()
    {
        return _passwordEncryption.GenerateSecurityStamp();
    }

    public bool CheckSecurityStampAsync(Guid userId, string SecurityStamp)
    {
        var user = _dbContext.Users.Where(x => x.Id == userId && x.SecurityStamp == SecurityStamp).FirstOrDefault();

        if (user is null)
            return false;

        return true;
    }
}
