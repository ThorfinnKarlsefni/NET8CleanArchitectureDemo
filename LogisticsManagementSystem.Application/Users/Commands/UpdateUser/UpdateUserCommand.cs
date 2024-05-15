using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record UpdateUserCommand(
    Guid UserId,
    Guid? CompanyId,
    string Name,
    string? PhoneNumber,
    string? Email,
    string? Password,
    string? ConfirmPassword,
    Guid? Role
) : IRequest<ErrorOr<Updated>>;