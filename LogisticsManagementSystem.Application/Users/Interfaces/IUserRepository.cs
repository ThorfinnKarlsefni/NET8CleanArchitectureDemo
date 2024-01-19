using ErrorOr;
using LogisticsManagementSystem.Domain;
using Microsoft.AspNetCore.Identity;

namespace LogisticsManagementSystem.Application;

public interface IUserRepository
{
    Task<bool> UserExistsAsync(string UserName);
    Task<ErrorOr<IdentityResult>> CreateAsync(User user);
}
