using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class RoleSetEventHandler(IUserRolesRepository _userRolesRepository) : INotificationHandler<RoleSetEvent>
{
    public async Task Handle(RoleSetEvent notification, CancellationToken cancellationToken)
    {
        await _userRolesRepository.AddAsync(notification.UserRole, cancellationToken);
    }
}
