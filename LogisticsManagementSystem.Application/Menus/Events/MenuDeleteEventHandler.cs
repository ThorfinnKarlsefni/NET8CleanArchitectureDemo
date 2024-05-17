using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class MenuDeleteEventHandler(IRoleMenusRepository _roleMenusRepository) : INotificationHandler<MenuDeleteEvent>
{
    public async Task Handle(MenuDeleteEvent notification, CancellationToken cancellationToken)
    {
        await _roleMenusRepository.ExecuteDeleteAsync(notification.RoleId, cancellationToken);
    }
}
