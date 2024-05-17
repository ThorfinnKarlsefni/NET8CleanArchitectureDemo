using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Policies = Policy.SelfOrAdmin)]
public record CreatePermissionCommand(int? ParentId, string Name, string? Controller, string? Action, string? Method) : IAuthorizeAbleRequest<ErrorOr<Created>>;
