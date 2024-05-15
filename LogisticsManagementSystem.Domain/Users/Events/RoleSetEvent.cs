namespace LogisticsManagementSystem.Domain;

public record RoleSetEvent(UserRole UserRole) : IDomainEvent;
