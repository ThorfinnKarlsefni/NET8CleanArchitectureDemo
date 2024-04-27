using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record AllPermissionQuery() : IRequest<ErrorOr<List<Permission>>>;

