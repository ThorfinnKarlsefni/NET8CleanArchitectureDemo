using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class ListUserQueryHandler(
    IUserRepository _userRepository) : IRequestHandler<ListUserQuery, ErrorOr<ListUserResult>>
{
    public async Task<ErrorOr<ListUserResult>> Handle(ListUserQuery request, CancellationToken cancellationToken)
    {
        var (userList, totalCount) = await _userRepository.GetListUserAsync(request.PageNumber, request.PageSize, request.SearchKeyword, request.Disable, cancellationToken);

        var users = userList
            .Select(u => new ListUser(
                u.Id,
                u.UserName,
                u.Name,
                u.Avatar,
                u.PhoneNumber,
                u.CreatedAt,
                u.UserRoles
                    .Select(x => new ListUserRoleResult(x.Role.Id, x.Role.Name)).ToList(),
                new UserCompanyResult(u.Company?.Id, u.Company?.Name)
            ));

        return new ListUserResult(
            totalCount,
            request.PageNumber,
            request.PageSize,
            users.ToList());
    }
}
