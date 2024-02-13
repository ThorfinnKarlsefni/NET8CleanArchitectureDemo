using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record ListMenusQuery() : IRequest<ErrorOr<List<Menu>?>>;
