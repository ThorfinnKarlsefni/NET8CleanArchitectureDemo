
namespace LogisticsManagementSystem.Domain;

public abstract class Entity
{
    public virtual DateTime CreatedAt { get; init; }
    public virtual DateTime UpdatedAt { get; set; }
    public virtual DateTime? DeletedAt { get; set; }
    protected readonly List<IDomainEvent> _domainEvents = [];

    protected Entity()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = CreatedAt;
    }

    public List<IDomainEvent> PopDomainEvents()
    {
        var copy = _domainEvents.ToList();
        _domainEvents.Clear();
        return copy;
    }
    public void SetUpdateAt()
    {
        UpdatedAt = DateTime.Now;
    }

    public void SetDeletedAt()
    {
        DeletedAt = DateTime.Now;
    }
}
