namespace LogisticsManagementSystem.Domain;

public class PermissionRoles : Entity
{
    public Guid RoleId { get; private set; }
    public Guid PermissionId { get; private set; }
}
