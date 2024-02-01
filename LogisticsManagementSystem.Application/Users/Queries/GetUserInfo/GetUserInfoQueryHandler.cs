using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, ErrorOr<UserInfoResult>>
{
    private readonly IUserRepository _userRepository;

    public GetUserInfoQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UserInfoResult>> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(request.UserId);
        if (user is null)
            return Error.NotFound();
        return new UserInfoResult(user?.Name, user?.Avatar);
    }
}
