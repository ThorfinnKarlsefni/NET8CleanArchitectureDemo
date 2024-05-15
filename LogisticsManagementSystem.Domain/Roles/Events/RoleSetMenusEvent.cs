
namespace LogisticsManagementSystem.Domain;

public record RoleSetMenusEvent(List<RoleMenus> RoleMenus) : IDomainEvent;