using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record GetRolesQuery() : IRequest<ErrorOr<List<GetRolesResult>>>;
