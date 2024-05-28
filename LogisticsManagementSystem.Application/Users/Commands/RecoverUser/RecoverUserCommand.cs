using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Common.Security.Permissions.Permission.User.Update, Policies = Policy.SelfOrAdmin)]
public record RecoverUserCommand(Guid UserId) : IAuthorizeAbleRequest<ErrorOr<Updated>>;
