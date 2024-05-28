using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Common.Security.Permissions.Permission.Role.Delete, Policies = Policy.SelfOrAdmin)]
public record DeleteRoleCommand(Guid RoleId) : IAuthorizeAbleRequest<ErrorOr<Deleted>>;