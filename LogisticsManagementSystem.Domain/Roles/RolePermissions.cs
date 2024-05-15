namespace LogisticsManagementSystem.Domain;

public class RolePermissions
{
    public int PermissionId { get; private set; }
    public Permission Permission { get; set; } = null!;
    public Guid RoleId { get; private set; }
    public Role Role { get; set; } = null!;

    public RolePermissions(int permissionId, Guid roleId)
    {
        PermissionId = permissionId;
        RoleId = roleId;
    }
}

