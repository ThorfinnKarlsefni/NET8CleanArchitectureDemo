using Microsoft.AspNetCore.Identity;

namespace LogisticsManagementSystem.Domain;

public class UserRole : IdentityUserRole<Guid>
{
    public DateTime CreatedAt { get; private init; }
    public DateTime UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    public UserRole()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public void SetUpdateAt()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetDeletedAt()
    {
        DeletedAt = DateTime.UtcNow;
    }

}
