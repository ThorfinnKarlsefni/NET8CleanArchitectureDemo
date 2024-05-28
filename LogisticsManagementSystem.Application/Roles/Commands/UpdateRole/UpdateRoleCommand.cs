using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Common.Security.Permissions.Permission.Role.Update, Policies = Policy.SelfOrAdmin)]
public record UpdateRoleCommand(Guid RoleId, string Name, List<int> Menus) : IAuthorizeAbleRequest<ErrorOr<Updated>>;

