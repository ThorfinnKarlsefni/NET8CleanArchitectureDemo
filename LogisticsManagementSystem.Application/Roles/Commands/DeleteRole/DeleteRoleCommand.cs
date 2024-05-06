using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record DeleteRoleCommand(Guid RoleId) : IRequest<ErrorOr<Deleted>>;