using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class MenuSetEventHandler(IRoleMenusRepository _roleMenusRepository) : INotificationHandler<MenuSetEvent>
{
    public async Task Handle(MenuSetEvent @event, CancellationToken cancellationToken)
    {
        await _roleMenusRepository.AddRangeAsync(@event.RoleMenus, cancellationToken);
    }
}
