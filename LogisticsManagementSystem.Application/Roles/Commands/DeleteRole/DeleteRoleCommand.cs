using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record DeleteRoleCommand(string roleId) : IRequest<ErrorOr<Deleted>>;