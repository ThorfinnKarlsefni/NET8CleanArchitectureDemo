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

    public async Task<ErrorOr<Updated>> Handle(RecoverUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(request.Id);
        if (user is null)
            return Error.NotFound(description: "用户不存在");
        user.Recover();
        await _userRepository.SaveChangeAsync();
        return Result.Updated;
    }
}
