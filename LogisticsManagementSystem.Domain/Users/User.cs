
namespace LogisticsManagementSystem.Domain;

public class User : Entity
{
    public Guid Id { get; private set; }
    public string UserName { get; private set; }
    public string Name { get; private set; }
    public Company? Company { get; private set; }
    public Guid? CompanyId { get; private set; }
    public string? PhoneNumber { get; private set; } = string.Empty;
    public string? Email { get; private set; } = string.Empty;
    public string? Avatar { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; }
    public string SecurityStamp { get; private set; }
    public bool PhoneNumberConfirmed { get; private set; } = false;
    public bool LockoutEnabled { get; private set; } = false;
    public DateTime? LockoutEnd { get; private set; }
    public int TokenVersion { get; private set; }
    public List<UserRole> UserRoles { get; private set; } = [];

    public User(string userName, string name, Guid? companyId, string? phoneNumber)
    {
        UserName = userName;
        Name = name;
        CompanyId = companyId;
        PhoneNumber = phoneNumber;
    }

    public void UpdateUser(Guid? companyId, string name, string? phoneNumber, string? email)
    {
        CompanyId = companyId;
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public void UpdateRole(Guid userId, Guid? roleId)
    {
        UserRoles.Clear();
        if (roleId.HasValue)
        {
            UserRoles.Add(new UserRole { UserId = userId, RoleId = roleId.Value });

        }
    }

    public void Recover()
    {
        DeletedAt = null;
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
