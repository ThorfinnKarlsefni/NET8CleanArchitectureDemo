using ErrorOr;
using LogisticsManagementSystem.Application.Common.Security.Permissions;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Permission.Role.Update, Policies = Policy.SelfOrAdmin)]
public record UpdateRoleCommand(Guid RoleId, string Name, List<int> Menus) : IAuthorizeAbleRequest<ErrorOr<Updated>>;

