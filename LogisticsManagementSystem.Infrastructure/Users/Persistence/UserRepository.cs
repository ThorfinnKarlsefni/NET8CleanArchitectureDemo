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

    public async Task<User?> GetUserByUsernameWithAllInfoAsync(string username, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Where(x => string.Equals(x.NormalizedUserName, username.Trim().ToUpper()))
            .Include(x => x.Company)
            .FirstOrDefaultAsync(cancellationToken);

        if (user is not null)
        {
            await _dbContext.Entry(user)
            .Collection(x => x.UserRoles)
            .Query()
            .Include(x => x.Role)
                .ThenInclude(x => x.RolePermissions)
                .ThenInclude(x => x.Permission)
            .LoadAsync();
        }

        return user;
    }

    public async Task<User?> FindByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .Where(x => x.DeletedAt == null)
            .Where(x => x.Id == userId)
            .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
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
        return _passwordEncryption.HashPassword(password.Trim());
    }

    public string GenerateSecurityStamp()
    {
        return _passwordEncryption.GenerateSecurityStamp();
    }

    public bool CheckSecurityStamp(Guid userId, string SecurityStamp)
    {
        var user = _dbContext.Users.Where(x => x.Id == userId && x.SecurityStamp == SecurityStamp).FirstOrDefault();

        if (user is null)
            return false;

        return true;
    }
}
