using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Common.Security.Permissions.Permission.User.Update, Policies = Policy.SelfOrAdmin)]
public record UpdateUserCommand(
    Guid UserId,
    Guid? CompanyId,
    string Name,
    string? PhoneNumber,
    string? Email,
    string? Password,
    string? ConfirmPassword,
    Guid? RoleId
) : IAuthorizeAbleRequest<ErrorOr<Updated>>;