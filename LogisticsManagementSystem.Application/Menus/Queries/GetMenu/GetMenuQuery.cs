using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record GetMenuQuery(int Id) : IRequest<ErrorOr<Menu?>>;