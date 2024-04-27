using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record GetMenuTreeQuery() : IRequest<ErrorOr<List<Menu>>>;
