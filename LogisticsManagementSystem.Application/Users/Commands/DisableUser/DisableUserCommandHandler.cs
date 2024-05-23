using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class DisableUserCommandHandler(
    IUserRepository _userRepository) : IRequestHandler<DisableUserCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(DisableUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(command.UserId, cancellationToken);

        if (user is null)
            return Error.NotFound(description: "用户不存在");

        if (user.UserRoles.Any(x => x.Role.NormalizedName == "ADMIN"))
            return Error.Validation(description: "管理员角色无法禁用");

        await _userRepository.DeleteAsync(user, cancellationToken);
        return Result.Updated;
    }
}
