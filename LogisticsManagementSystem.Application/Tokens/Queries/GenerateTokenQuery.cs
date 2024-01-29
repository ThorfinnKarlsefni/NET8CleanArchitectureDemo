using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record GenerateTokenQuery(string Username, string Password) : IRequest<ErrorOr<GenerateTokenResult>>;
