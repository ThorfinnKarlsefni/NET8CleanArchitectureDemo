using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GetUserQueryHandler(
    IUserRepository _userRepository) : IRequestHandler<GetUserQuery, ErrorOr<GetUserResult>>
{
    public async Task<ErrorOr<GetUserResult>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(request.Id, cancellationToken);
        if (user is null)
            return Error.NotFound(description: "用户不存在");

        return new GetUserResult(
            user.Company?.Name,
            user.Name,
            user.Avatar,
            user.UserRoles.Select(x => x.Role.Name).ToList());
    }
}
