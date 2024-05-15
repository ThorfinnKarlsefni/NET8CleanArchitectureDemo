using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Common.Security.Permissions.Permission.Menu.Get, Policies = Policy.SelfOrAdmin)]
public record GetMenuQuery(int Id) : IRequest<ErrorOr<Menu?>>;