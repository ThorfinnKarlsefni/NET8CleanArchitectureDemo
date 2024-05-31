using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Common.Security.Permissions.Permission.Company.Disable, Policies = Policy.SelfOrAdmin)]
public record DisableCompanyCommand(
    Guid CompanyId,
    bool IsDisable
) : IAuthorizeAbleRequest<ErrorOr<Updated>>;
