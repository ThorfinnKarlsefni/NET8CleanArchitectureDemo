using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Common.Security.Permissions.Permission.User.Create, Policies = Policy.SelfOrAdmin)]
public record CreateUserCommand(
    string UserName,
    string Name,
    Guid? CompanyId,
    string? PhoneNumber,
    string? Avatar,
    string Password,
    string ConfirmPassword,
    Guid? RoleId) : IAuthorizeAbleRequest<ErrorOr<Created>>;
