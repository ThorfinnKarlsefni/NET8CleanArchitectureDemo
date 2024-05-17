using ErrorOr;
using LogisticsManagementSystem.Application.Common.Security.Permissions;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Permission.Role.Get, Policies = Policy.SelfOrAdmin)]
public record CreateRoleCommand(string Name, List<int> MenuIds) : IAuthorizeAbleRequest<ErrorOr<Created>>;