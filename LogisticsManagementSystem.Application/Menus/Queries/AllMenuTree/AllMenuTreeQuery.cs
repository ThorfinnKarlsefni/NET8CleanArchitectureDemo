using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record GetMenuAllTreeQuery() : IRequest<ErrorOr<List<Menu>>>;

