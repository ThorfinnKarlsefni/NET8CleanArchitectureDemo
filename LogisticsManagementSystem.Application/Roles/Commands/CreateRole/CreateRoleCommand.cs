using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Common.Security.Permissions.Permission.Role.Create, Policies = Policy.SelfOrAdmin)]
public record CreateRoleCommand(string Name, List<int> MenuIds) : IAuthorizeAbleRequest<ErrorOr<Created>>;