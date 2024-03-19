using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record DisableUserCommand(string Id) : IRequest<ErrorOr<Updated>>;
