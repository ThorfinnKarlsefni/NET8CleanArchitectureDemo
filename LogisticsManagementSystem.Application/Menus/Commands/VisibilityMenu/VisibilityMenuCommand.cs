using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record VisibilityMenuCommand(int Id) : IRequest<ErrorOr<Updated>>;
