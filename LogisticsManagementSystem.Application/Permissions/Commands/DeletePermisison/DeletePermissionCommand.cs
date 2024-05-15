using ErrorOr;

namespace LogisticsManagementSystem.Application;

public record DeletePermissionCommand(int PermissionId) : IAuthorizeAbleRequest<ErrorOr<Deleted>>;

