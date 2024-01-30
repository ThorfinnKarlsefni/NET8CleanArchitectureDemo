using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record LoginByUserNameCommand(string Username, string Password) : IRequest<ErrorOr<User>>;
