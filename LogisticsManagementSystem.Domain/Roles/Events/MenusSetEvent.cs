
namespace LogisticsManagementSystem.Domain;

public record MenuSetEvent(List<RoleMenus> RoleMenus) : IDomainEvent;