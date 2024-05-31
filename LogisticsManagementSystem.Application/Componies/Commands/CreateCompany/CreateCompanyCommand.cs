using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Common.Security.Permissions.Permission.Company.Get, Policies = Policy.SelfOrAdmin)]
public record CreateCompanyCommand(
    string Name,
    string? PhoneNumber,
    string? Address,
    bool IsDisable
) : IAuthorizeAbleRequest<ErrorOr<Created>>;

