using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record CreateRoleCommand(string Name) : IRequest<ErrorOr<Created>>;