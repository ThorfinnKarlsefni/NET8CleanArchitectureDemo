using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Policies = Policy.SelfOrAdmin)]
public record UpdatePermissionCommand(int PermissionId, int? ParentId, string Name, string? Controller, string? Action, string? Method) : IAuthorizeAbleRequest<ErrorOr<Updated>>;

