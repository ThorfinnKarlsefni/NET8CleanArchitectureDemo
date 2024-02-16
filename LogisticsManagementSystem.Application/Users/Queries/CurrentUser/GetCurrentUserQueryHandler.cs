using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, ErrorOr<CurrentUserResult>>
{
    private readonly IUserRepository _userRepository;

    public GetCurrentUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<CurrentUserResult>> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(request.UserId);
        if (user is null)
            return Error.Validation(description: "用户不存在");
        return new CurrentUserResult(user?.Name, user?.Avatar);
    }
}
