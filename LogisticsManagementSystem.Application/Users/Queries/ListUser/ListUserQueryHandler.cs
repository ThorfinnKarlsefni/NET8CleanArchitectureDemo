using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class ListUserQueryHandler : IRequestHandler<ListUserQuery, ErrorOr<ListUserResult?>>
{
    private readonly IUserRepository _userRepository;
    public ListUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<ListUserResult?>> Handle(ListUserQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetListUserAsync(request.PageNumber, request.PageSize, request.SearchKeyword);
    }
}
