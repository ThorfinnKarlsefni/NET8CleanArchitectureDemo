using ErrorOr;
using LogisticsManagementSystem.Application.Common.Security.Permissions;
using MediatR;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Permission.Menu.Create, Policies = Policy.SelfOrAdmin)]
public record CreateMenuCommand(int? ParentId, string Name, string Path, string? Icon, string? Component, int? Sort, bool Visibility) : IRequest<ErrorOr<Created>>;
