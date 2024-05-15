using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class RecoverUserCommandHandler(
    IUserRepository _userRepository) : IRequestHandler<RecoverUserCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(RecoverUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(command.UserId, cancellationToken);
        if (user is null)
            return Error.NotFound(description: "用户不存在");
        user.Recover();
        await _userRepository.UpdateAsync(user, cancellationToken);
        return Result.Updated;
    }
}
