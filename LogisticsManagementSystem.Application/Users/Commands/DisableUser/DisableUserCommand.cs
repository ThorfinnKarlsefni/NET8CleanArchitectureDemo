using ErrorOr;
using LogisticsManagementSystem.Application.Common.Security.Permissions;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Permission.User.Delete, Policies = Policy.SelfOrAdmin)]
public record DisableUserCommand(Guid UserId) : IAuthorizeAbleRequest<ErrorOr<Updated>>;
