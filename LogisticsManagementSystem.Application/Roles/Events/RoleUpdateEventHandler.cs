using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class RoleUpdateEventHandler(
    IUserRolesRepository _userRolesRepository
    ) : INotificationHandler<RoleUpdateEvent>
{
    public async Task Handle(RoleUpdateEvent notification, CancellationToken cancellationToken)
    {
        var userRole = await _userRolesRepository.GetUserRoleByUserIdAsync(notification.UserId, cancellationToken);

        if (userRole is not null)
        {
            await _userRolesRepository.DeleteAsync(userRole, cancellationToken);
        }

        if (notification.RoleId.HasValue)
        {
            await _userRolesRepository.AddAsync(new UserRole(notification.UserId, notification.RoleId.Value), cancellationToken);
        }
    }
}
