using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record CreateUserCommand(string UserName, string Name, Guid? companyId, string? PhoneNumber, string? Avatar, string Password, string ConfirmPassword, List<string>? RoleId) : IRequest<ErrorOr<Created>>;
