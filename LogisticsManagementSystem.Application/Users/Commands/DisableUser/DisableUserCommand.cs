using ErrorOr;


namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Common.Security.Permissions.Permission.User.Delete, Policies = Policy.SelfOrAdmin)]
public record DisableUserCommand(Guid UserId) : IAuthorizeAbleRequest<ErrorOr<Updated>>;
