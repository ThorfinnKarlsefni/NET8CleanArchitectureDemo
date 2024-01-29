using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GenerateTokenQueryHandler : IRequestHandler<GenerateTokenQuery, ErrorOr<GenerateTokenResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public GenerateTokenQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<GenerateTokenResult>> Handle(GenerateTokenQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByNameAsync(request.Username);
        if (user is null)
            return Error.Validation(description: "用户不存在");

        var ok = await _userRepository.CheckPasswordAsync(user, request.Password);
        if (!ok)
            return Error.Validation(description: "用户名或密码错误");

        var roles = await _userRepository.GetRolesAsync(user);
        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Name, user?.Company.ToString(), roles.ToList());

        return new GenerateTokenResult(
            user?.Name,
            user?.Avatar,
            token
        );
    }
}
