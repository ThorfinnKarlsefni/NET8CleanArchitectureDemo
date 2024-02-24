using System.Dynamic;
using Microsoft.AspNetCore.Identity;

namespace LogisticsManagementSystem.Domain;

public class User : IdentityUser<Guid>
{
    public Company? Company { get; private set; }
    public Guid? CompanyId { get; private set; }
    public string Name { get; set; } = string.Empty;
    public string? Avatar { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private init; }
    public DateTime UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public int TokenVersion { get; private set; }
    public List<UserRole> UserRoles { get; private set; } = new List<UserRole>();
    public User(string userName, string name, Guid? companyId, string? phoneNumber) : base(userName)
    {
        Name = name;
        CompanyId = companyId;
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

    public void SetTokenVersionIncrement()
    {
        TokenVersion = TokenVersion++;
    }

    public void SetAvatar(string? avatar)
    {
        Avatar = avatar == null ? new RandomAvatar().GetRandomAvatar() : avatar;
    }
}
