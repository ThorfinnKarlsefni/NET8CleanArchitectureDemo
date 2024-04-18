using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record AllMenuQuery() : IRequest<ErrorOr<List<Menu>>>;

