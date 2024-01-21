using ErrorOr;
using LogisticsManagementSystem.Domain;
using Microsoft.AspNetCore.Identity;

namespace LogisticsManagementSystem.Application;

public interface IUserServices
{
    public Task<ErrorOr<IdentityResult>> RegisterAndCreateAsync(User user);
}
