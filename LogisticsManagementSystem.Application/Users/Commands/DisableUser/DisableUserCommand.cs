using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record DisableUserCommand(Guid UserId) : IRequest<ErrorOr<Updated>>;
