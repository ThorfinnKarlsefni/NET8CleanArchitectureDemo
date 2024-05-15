using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record CreateRoleCommand(string Name, List<int>? MenuIds) : IRequest<ErrorOr<Created>>;