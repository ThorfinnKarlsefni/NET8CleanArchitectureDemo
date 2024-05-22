using ErrorOr;

using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

[Authorize(Policies = Policy.SelfOrAdmin)]
public record GetComponentMenusQuery() : IAuthorizeAbleRequest<ErrorOr<List<Menu>>>;
