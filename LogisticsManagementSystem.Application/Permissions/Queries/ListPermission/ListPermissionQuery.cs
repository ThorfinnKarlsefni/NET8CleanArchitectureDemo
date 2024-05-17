using ErrorOr;
using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

[Authorize(Policies = Policy.SelfOrAdmin)]
public record ListPermissionQuery() : IAuthorizeAbleRequest<ErrorOr<List<Permission>>>;

