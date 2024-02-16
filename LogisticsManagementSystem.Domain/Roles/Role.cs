using Microsoft.AspNetCore.Identity;

namespace LogisticsManagementSystem.Domain;

public class Role : IdentityRole<Guid>
{
    public DateTime CreatedAt { get; private init; }
    public DateTime UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public Role(string Name) : base(Name)
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
