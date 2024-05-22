using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

// role menu relations using
public record ListPermissionQuery() : IRequest<ErrorOr<List<Permission>>>;

