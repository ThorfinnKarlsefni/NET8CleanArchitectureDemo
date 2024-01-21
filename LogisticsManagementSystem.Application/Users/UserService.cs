using ErrorOr;
using LogisticsManagementSystem.Domain;
using Microsoft.AspNetCore.Identity;

namespace LogisticsManagementSystem.Application;

public class UserService : IUserServices
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<IdentityResult>> RegisterAndCreateAsync(User user)
    {
        var result = await _userRepository.CreateAsync(user);
        if (!result.Succeeded)
            return Error.Conflict(description: result.Errors.First().Description.ToString());
        return result;
    }
}
