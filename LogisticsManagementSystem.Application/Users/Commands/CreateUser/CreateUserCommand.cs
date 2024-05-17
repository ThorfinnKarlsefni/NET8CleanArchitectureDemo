using ErrorOr;
using LogisticsManagementSystem.Application.Common.Security.Permissions;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Permission.User.Create, Policies = Policy.SelfOrAdmin)]
public record CreateUserCommand(
    string UserName,
    string Name,
    Guid? CompanyId,
    string? PhoneNumber,
    string? Avatar,
    string Password,
    string ConfirmPassword,
    Guid? RoleId) : IAuthorizeAbleRequest<ErrorOr<Created>>;
