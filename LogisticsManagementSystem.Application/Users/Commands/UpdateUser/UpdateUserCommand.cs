using ErrorOr;
using LogisticsManagementSystem.Application.Common.Security.Permissions;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Permission.User.Update, Policies = Policy.SelfOrAdmin)]
public record UpdateUserCommand(
    Guid UserId,
    Guid? CompanyId,
    string Name,
    string? PhoneNumber,
    string? Email,
    string? Password,
    string? ConfirmPassword,
    Guid? Role
) : IAuthorizeAbleRequest<ErrorOr<Updated>>;