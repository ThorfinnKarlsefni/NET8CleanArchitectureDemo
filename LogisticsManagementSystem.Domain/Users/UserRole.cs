
namespace LogisticsManagementSystem.Domain;

public class UserRole
{
    public User User { get; set; } = null!;
    public Guid UserId { get; set; }
    public Role Role { get; set; } = null!;
    public Guid RoleId { get; set; }
}
