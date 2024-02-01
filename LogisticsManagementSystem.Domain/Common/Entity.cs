namespace LogisticsManagementSystem.Domain;

public class Entity
{
    public virtual DateTime CreatedAt { get; private init; }
    public virtual DateTime UpdatedAt { get; private set; }
    public virtual DateTime? DeletedAt { get; private set; }

    public Entity()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = CreatedAt;
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
