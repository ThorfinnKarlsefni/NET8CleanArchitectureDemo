using ErrorOr;

using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

[Authorize(Policies = Policy.SelfOrAdmin)]
public record GetPermissionMenuQuery() : IAuthorizeAbleRequest<ErrorOr<List<Menu>>>;
