
namespace LogisticsManagementSystem.Domain;

public record RoleMenuSetEvent(List<MenuRole> MenuRoles) : IDomainEvent;