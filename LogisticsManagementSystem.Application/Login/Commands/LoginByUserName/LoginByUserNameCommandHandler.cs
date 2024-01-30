using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class LoginByUserNameQueryHandler : IRequestHandler<LoginByUserNameCommand, ErrorOr<User>>
{
    private readonly IUserRepository _userRepository;

    public LoginByUserNameQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<User>> Handle(LoginByUserNameCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByNameAsync(request.Username);
        if (user is null)
            return Error.Validation(description: "用户名或密码错误");


        var ok = await _userRepository.CheckPasswordAsync(user, request.Password);
        if (!ok)
            return Error.Validation(description: "用户名或密码错误");

        return user;
    }
}
