using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record UpdateRoleCommand(string Id, string Name, string? NormalizedName, List<int> Menus) : IRequest<ErrorOr<Updated>>;

