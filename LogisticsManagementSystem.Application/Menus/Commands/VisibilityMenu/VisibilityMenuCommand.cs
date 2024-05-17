using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

[Authorize(Policies = Policy.SelfOrAdmin)]
public record VisibilityMenuCommand(int Id) : IAuthorizeAbleRequest<ErrorOr<Updated>>;
