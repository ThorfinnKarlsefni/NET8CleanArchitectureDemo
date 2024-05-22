using ErrorOr;
using LogisticsManagementSystem.Application.Common.Security.Permissions;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Permission.Role.Update, Policies = Policy.SelfOrAdmin)]
public record GetRolePermissionsQuery(Guid RoleId) : IAuthorizeAbleRequest<ErrorOr<List<int>>>;