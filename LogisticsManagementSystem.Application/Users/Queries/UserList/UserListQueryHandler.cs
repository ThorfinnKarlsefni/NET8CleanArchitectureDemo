using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class UserListQueryHandler : IRequestHandler<UserListQuery, ErrorOr<UserListResult?>>
{
    private readonly IUserRepository _userRepository;

    public UserListQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UserListResult?>> Handle(UserListQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetUserListAsync(request.PageNumber, request.PageSize, request.SearchKeyword, request.Disable, cancellationToken);
    }
}
