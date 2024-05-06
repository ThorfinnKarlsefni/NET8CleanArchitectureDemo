using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class RecoverUserCommandHandler : IRequestHandler<RecoverUserCommand, ErrorOr<Updated>>
{
    private readonly IUserRepository _userRepository;

    public RecoverUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Updated>> Handle(RecoverUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(command.Id, cancellationToken);
        if (user is null)
            return Error.NotFound(description: "用户不存在");
        user.Recover();
        await _userRepository.UpdateAsync(user, cancellationToken);
        return Result.Updated;
    }
}
