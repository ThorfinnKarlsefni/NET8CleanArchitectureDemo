using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GenerateTokenQueryHandler : IRequestHandler<GenerateTokenCommand, ErrorOr<GenerateTokenResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public GenerateTokenQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<GenerateTokenResult>> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
    {
        if (request.User is null)
            return Error.Validation(description: "登录失败,用户不存在");

        var roles = await _userRepository.GetRolesAsync(request.User);
        var token = _jwtTokenGenerator.GenerateToken(request.User.Id, request.User.Name, request.User?.CompanyId.ToString(), roles.ToList());

        return new GenerateTokenResult(token);
    }
}
