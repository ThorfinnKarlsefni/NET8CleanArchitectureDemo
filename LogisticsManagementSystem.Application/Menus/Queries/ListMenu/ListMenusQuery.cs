using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Common.Security.Permissions.Permission.User.Get, Policies = Policy.SelfOrAdmin)]
public record ListMenusQuery() : IRequest<ErrorOr<List<Menu>>>;
