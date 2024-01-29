using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record CreateUserCommand(string Name, string UserName, string? PhoneNumber, string? Avatar, string Password, string ConfirmPassword) : IRequest<ErrorOr<Created>>;
