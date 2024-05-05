using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class CurrentUserQueryHandler : IRequestHandler<CurrentUserQuery, ErrorOr<CurrentUserResult>>
{
    private readonly IUserRepository _userRepository;

    public CurrentUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<CurrentUserResult>> Handle(CurrentUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(request.UserId);
        if (user is null)
            return Error.NotFound(description: "用户不存在");

        return new CurrentUserResult(user?.Name, user?.Avatar);
    }
}
