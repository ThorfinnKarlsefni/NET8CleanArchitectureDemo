using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class LogoutCommandHandler(
    ICurrentUserProvider _currentUserProvider,
    IUserRepository _userRepository) : IRequestHandler<LogoutCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserProvider.GetCurrentUser();
        var user = await _userRepository.FindByIdAsync(currentUser.Id, cancellationToken);

        if (user is null)
            return Error.Conflict(description: "用户不存在");

        user.SecurityStamp = _userRepository.GenerateSecurityStamp();

        await _userRepository.UpdateAsync(user, cancellationToken);

        return Result.Success;
    }
}
