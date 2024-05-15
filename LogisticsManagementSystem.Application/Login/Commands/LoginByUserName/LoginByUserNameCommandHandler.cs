using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class LoginByUserNameQueryHandler(
    IUserRepository _userRepository
) : IRequestHandler<LoginByUserNameCommand, ErrorOr<User>>
{
    public async Task<ErrorOr<User>> Handle(LoginByUserNameCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByNameAsync(request.Username, cancellationToken);

        if (user is null)
            return Error.NotFound(description: "用户名或密码错误");

        var ok = _userRepository.CheckPassword(user.PasswordHash!, request.Password);

        if (!ok)
            return Error.NotFound(description: "用户名或密码错误");

        return user;
    }
}
