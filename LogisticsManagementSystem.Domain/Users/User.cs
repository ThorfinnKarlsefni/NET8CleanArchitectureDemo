using Microsoft.AspNetCore.Identity;

namespace LogisticsManagementSystem.Domain;

public class User : IdentityUser<Guid>
{
    public Guid? CompanyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Avatar { get; set; } = string.Empty;
    public DateTime CreatedAt { get; private init; }
    public DateTime UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    public User(string userName, string name, string? phoneNumber, string? avatar) : base(userName)
    {
        Name = name;
        Avatar = avatar;
        PhoneNumber = phoneNumber;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
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
