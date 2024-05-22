using ErrorOr;
using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Common.Security.Permissions.Permission.Role.Get, Policies = Policy.SelfOrAdmin)]
public record ListMenusQuery() : IAuthorizeAbleRequest<ErrorOr<List<Menu>>>;
