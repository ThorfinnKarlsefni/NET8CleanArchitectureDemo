using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class DisableUserCommandHandler : IRequestHandler<DisableUserCommand, ErrorOr<Updated>>
{
    private readonly IUserRepository _userRepository;

    public DisableUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Updated>> Handle(DisableUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(command.Id);

        if (user is null)
            return Error.NotFound(description: "用户不存在");

        if (user.UserRoles.Any(x => x.Role.NormalizedName == "ADMIN"))
            return Error.Validation(description: "管理员角色无法禁用");

        user.SetDeletedAt();
        await _userRepository.SaveChangeAsync();
        return Result.Updated;
    }
}
