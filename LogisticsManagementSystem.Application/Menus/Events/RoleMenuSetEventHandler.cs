using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class RoleMenuSetEventHandler(IMenuRolesRepository _menuRolesRepository) : INotificationHandler<RoleMenuSetEvent>
{
    public async Task Handle(RoleMenuSetEvent @event, CancellationToken cancellationToken)
    {
        await _menuRolesRepository.AddRangeAsync(@event.MenuRoles, cancellationToken);
    }
}
