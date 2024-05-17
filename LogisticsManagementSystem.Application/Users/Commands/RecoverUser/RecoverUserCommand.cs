using ErrorOr;
using LogisticsManagementSystem.Application.Common.Security.Permissions;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Permission.User.Update, Policies = Policy.SelfOrAdmin)]
public record RecoverUserCommand(Guid UserId) : IAuthorizeAbleRequest<ErrorOr<Updated>>;
