namespace LogisticsManagementSystem.Domain;

public record MenuDeleteEvent(Guid RoleId) : IDomainEvent;
