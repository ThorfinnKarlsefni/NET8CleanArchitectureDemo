using ErrorOr;
using LogisticsManagementSystem.Application.Common.Security.Permissions;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Permission.Role.Delete, Policies = Policy.SelfOrAdmin)]
public record DeleteRoleCommand(Guid RoleId) : IAuthorizeAbleRequest<ErrorOr<Deleted>>;