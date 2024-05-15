namespace LogisticsManagementSystem.Domain;

public class RoleMenus
{
    public int MenuId { get; private set; }
    public Menu Menu { get; private set; } = null!;
    public Guid RoleId { get; private set; }
    public Role Role { get; private set; } = null!;

    public RoleMenus(int menuId, Guid roleId)
    {
        MenuId = menuId;
        RoleId = roleId;
    }
}
