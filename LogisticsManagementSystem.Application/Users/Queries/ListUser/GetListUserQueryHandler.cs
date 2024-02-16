using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, ErrorOr<List<ListUserResponse>?>>
{
    private readonly IUserRepository _userRepository;

    public GetListUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<List<ListUserResponse>?>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetListUserAsync();
    }
}
