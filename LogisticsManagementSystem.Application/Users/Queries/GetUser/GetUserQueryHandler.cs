using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ErrorOr<GetUserResult>>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<GetUserResult>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(request.Id);
        if (user is null)
            return Error.NotFound(description: "用户不存在");

        return new GetUserResult(
            user.Id,
            user.Company?.Name,
            user.UserName,
            user.Name,
            user.PhoneNumber,
            user.Email,
            user.CreatedAt,
            user.UserRoles.Select(ur => new GetUserRoleList(ur.Role.Id, ur.Role.Name)));
    }
}
