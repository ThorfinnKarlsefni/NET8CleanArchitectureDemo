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

    public async Task<ErrorOr<GenerateTokenResult>> Handle(GenerateTokenCommand command, CancellationToken cancellationToken)
    {
        if (command.User is null)
            return Error.Validation(description: "登录失败,用户不存在");

        var roles = await _userRepository.GetRolesAsync(command.User);
        List<string> permissions = new List<string>();

        // Add strings to the list
        permissions.Add("123");
        permissions.Add("12312");
        var token = _jwtTokenGenerator.GenerateToken(command.User.Id, command.User.Name, command.User?.CompanyId.ToString(), permissions, roles.ToList());

        return new GenerateTokenResult(token);
    }
}
