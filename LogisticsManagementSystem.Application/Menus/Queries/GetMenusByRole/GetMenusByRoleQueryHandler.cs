using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GetMenusByRoleQueryHandler(IMenuRepository _menuRepository,
IUserRepository _userRepository) : IRequestHandler<GetMenusByRoleQuery, ErrorOr<List<Menu>>>
{
    public async Task<ErrorOr<List<Menu>>> Handle(GetMenusByRoleQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(request.UserId, cancellationToken);

        var roleId = user?.UserRoles?.FirstOrDefault()?.RoleId;
        if (user is null || !roleId.HasValue)
        {
            return new List<Menu>();
        }

        var isAdmin = false;
        if (user.UserRoles.Any(x => x.Role.Name == CleanArchitecture.Application.Common.Security.Roles.Role.Admin))
        {
            isAdmin = true;
        }

        return await _menuRepository.GetMenusByRoleIdAsync(roleId.GetValueOrDefault(), isAdmin, cancellationToken);
    }
}
