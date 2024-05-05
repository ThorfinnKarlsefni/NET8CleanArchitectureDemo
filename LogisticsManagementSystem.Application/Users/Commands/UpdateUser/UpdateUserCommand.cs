using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record UpdateUserCommand(
    string Id,
    Guid? CompanyId,
    string Name,
    string? PhoneNumber,
    string? Email,
    string? Password,
    string? ConfirmPassword,
    Guid? Role
) : IRequest<ErrorOr<Updated>>;