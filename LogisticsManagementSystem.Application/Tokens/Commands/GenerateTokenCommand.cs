using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record GenerateTokenCommand(User User) : IRequest<ErrorOr<GenerateTokenResult>>;
