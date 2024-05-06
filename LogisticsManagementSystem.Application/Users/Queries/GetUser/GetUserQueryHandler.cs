using System.Globalization;
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
        var user = await _userRepository.FindByIdAsync(request.Id, cancellationToken);
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
            user.UserRoles.Select(x => new GetUserRoleList(x.RoleId, x.Role.Name)));
    }
}
