namespace LogisticsManagementSystem.Domain;

public record RoleUpdateEvent(Guid UserId, Guid? RoleId) : IDomainEvent;