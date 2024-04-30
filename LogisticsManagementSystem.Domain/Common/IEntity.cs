namespace LogisticsManagementSystem.Domain;

public interface IEntity
{
    List<IDomainEvent> PopDomainEvents();
}
