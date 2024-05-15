using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record GetPermissionsQuery() : IRequest<ErrorOr<List<Permission>>>;

