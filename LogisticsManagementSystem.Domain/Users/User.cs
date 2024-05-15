
using ErrorOr;

namespace LogisticsManagementSystem.Domain;

public class User : Entity
{
    public Guid Id { get; set; }
    public Company? Company { get; set; }
    public Guid? CompanyId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string NormalizedUserName { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Avatar { get; set; }
    public string PasswordHash { get; set; } = string.Empty;
    public string SecurityStamp { get; set; } = string.Empty;
    public bool PhoneNumberConfirmed { get; set; } = false;
    public bool LockoutEnabled { get; set; } = false;
    public DateTime? LockoutEnd { get; set; }
    public List<UserRole> UserRoles { get; set; } = [];

    public User(string userName, string name, Guid? companyId, string? phoneNumber)
    {
        Id = Guid.NewGuid();
        UserName = userName.Trim();
        NormalizedUserName = userName.ToUpper().Trim();
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
            // UserRoles.Add(new UserRole { UserId = userId, RoleId = roleId.Value });
        }
    }

    public ErrorOr<Success> SetRole(List<Role> roles, Guid userId, Guid roleId)
    {
        if (!roles.Any(x => x.Id == roleId))
        {
            return Error.Validation(description: "角色不存在");
        }

        var userRole = new UserRole(userId, roleId);
        _domainEvents.Add(new RoleSetEvent(userRole));

        return Result.Success;
    }

    public void Recover()
    {
        DeletedAt = null;
    }

    public void SetAvatar(string? avatar)
    {
        Avatar = avatar == null ? new RandomAvatar().GetRandomAvatar() : avatar;
    }

    public User()
    {

    }
}
