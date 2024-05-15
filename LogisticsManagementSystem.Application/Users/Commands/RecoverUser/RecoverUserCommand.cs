using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record RecoverUserCommand(Guid UserId) : IRequest<ErrorOr<Updated>>;
