using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Policies = Policy.SelfOrAdmin)]
public record DeletePermissionCommand(int PermissionId) : IAuthorizeAbleRequest<ErrorOr<Deleted>>;

