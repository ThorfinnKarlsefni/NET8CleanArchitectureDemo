using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Common.Security.Permissions.Permission.Role.Create, Policies = Policy.SelfOrAdmin)]
public record UpdateRoleCompaniesCommand(
    Guid RoleId,
    List<Guid> CompanyIds
) : IAuthorizeAbleRequest<ErrorOr<Updated>>;