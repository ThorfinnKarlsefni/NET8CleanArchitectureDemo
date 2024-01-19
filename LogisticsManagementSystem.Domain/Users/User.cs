using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LogisticsManagementSystem.Domain;

public class User : IdentityUser<Guid>
{
    public string? Name { get; set; }
    public string? Avatar { get; set; }
    public Guid? Company { get; set; }
    public DateTime CreatedAt { get; private init; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public User(string userName, string? phoneNumber) : base(userName)
    {
        PhoneNumber = phoneNumber;
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
