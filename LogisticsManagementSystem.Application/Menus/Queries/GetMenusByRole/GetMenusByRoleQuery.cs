using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record GetMenusByRoleQuery(Guid UserId) : IRequest<ErrorOr<List<Menu>>>;