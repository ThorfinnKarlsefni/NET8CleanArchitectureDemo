namespace LogisticsManagementSystem.Domain;

public record RoleDeleteEvent(UserRole UserRole) : IDomainEvent;