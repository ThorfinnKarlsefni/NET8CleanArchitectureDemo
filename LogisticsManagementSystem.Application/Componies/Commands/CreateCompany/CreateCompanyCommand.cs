using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Common.Security.Permissions.Permission.Company.Get, Policies = Policy.SelfOrAdmin)]
public record CreateCompanyCommand(
    string CompanyName,
    string? CompanyPhone,
    string? CompanyAddress,
    bool IsDisable
) : IAuthorizeAbleRequest<ErrorOr<Created>>;

