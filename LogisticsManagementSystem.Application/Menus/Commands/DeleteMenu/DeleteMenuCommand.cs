using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Policies = Policy.SelfOrAdmin)]
public record DeleteMenuCommand(int Id) : IAuthorizeAbleRequest<ErrorOr<Deleted>>;
