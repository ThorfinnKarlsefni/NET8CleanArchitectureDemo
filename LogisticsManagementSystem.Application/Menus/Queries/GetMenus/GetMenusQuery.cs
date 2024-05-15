using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record GetMenusQuery() : IRequest<ErrorOr<List<Menu>>>;

