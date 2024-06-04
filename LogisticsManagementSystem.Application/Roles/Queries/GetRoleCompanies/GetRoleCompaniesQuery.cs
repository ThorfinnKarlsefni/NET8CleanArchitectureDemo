using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Common.Security.Permissions.Permission.Role.Create, Policies = Policy.SelfOrAdmin)]
public record GetRoleCompaniesQuery(
    Guid RoleId
) : IAuthorizeAbleRequest<ErrorOr<List<Guid>>>;
