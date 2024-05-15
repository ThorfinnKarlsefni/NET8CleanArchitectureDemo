using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class RoleSetMenusEventHandler(IRoleMenusRepository _roleMenusRepository) : INotificationHandler<RoleSetMenusEvent>
{
    public async Task Handle(RoleSetMenusEvent @event, CancellationToken cancellationToken)
    {
        await _roleMenusRepository.AddRangeAsync(@event.RoleMenus, cancellationToken);
    }
}
