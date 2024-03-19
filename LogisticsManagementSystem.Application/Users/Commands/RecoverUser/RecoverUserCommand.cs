using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record RecoverUserCommand(string Id) : IRequest<ErrorOr<Updated>>;
