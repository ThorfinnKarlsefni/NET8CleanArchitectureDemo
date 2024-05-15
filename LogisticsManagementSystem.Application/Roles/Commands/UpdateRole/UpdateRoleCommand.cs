using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record UpdateRoleCommand(Guid RoleId, string Name, List<int> Menus) : IRequest<ErrorOr<Updated>>;

