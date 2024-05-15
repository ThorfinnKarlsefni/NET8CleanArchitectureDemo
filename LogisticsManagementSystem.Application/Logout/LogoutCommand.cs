using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record LogoutCommand() : IRequest<ErrorOr<Success>>;

