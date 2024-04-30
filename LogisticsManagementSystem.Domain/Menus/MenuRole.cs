

namespace LogisticsManagementSystem.Domain;

public class MenuRole
{
    public int MenuId { get; set; }
    public Menu Menu { get; set; } = null!;
    public Guid RoleId { get; set; }
    public Role Role { get; set; } = null!;
}

