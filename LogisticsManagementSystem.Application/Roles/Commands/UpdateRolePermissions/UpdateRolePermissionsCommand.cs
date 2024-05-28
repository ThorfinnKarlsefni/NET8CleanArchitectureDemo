using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Common.Security.Permissions.Permission.Role.Update, Policies = Policy.SelfOrAdmin)]
public record UpdateRolePermissionsCommand(
    Guid RoleId,
    List<int> PermissionIds) : IAuthorizeAbleRequest<ErrorOr<Updated>>;
