using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Policies = Policy.SelfOrAdmin)]
public record VisibilityMenuCommand(int MenuId) : IAuthorizeAbleRequest<ErrorOr<Updated>>;
