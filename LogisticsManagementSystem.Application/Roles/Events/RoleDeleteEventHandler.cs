using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class RoleDeleteEventHandler(IUserRolesRepository _userRolesRepository) : INotificationHandler<RoleDeleteEvent>
{
    public async Task Handle(RoleDeleteEvent notification, CancellationToken cancellationToken)
    {
        await _userRolesRepository.DeleteAsync(notification.UserRole, cancellationToken);
    }
}
