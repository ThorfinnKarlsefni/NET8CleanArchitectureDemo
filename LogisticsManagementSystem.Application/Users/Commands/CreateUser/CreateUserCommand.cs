using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record CreateUserCommand(
    string UserName,
    string Name,
    Guid? CompanyId,
    string? PhoneNumber,
    string? Avatar,
    string Password,
    string ConfirmPassword,
    Guid? RoleId) : IRequest<ErrorOr<Created>>;
