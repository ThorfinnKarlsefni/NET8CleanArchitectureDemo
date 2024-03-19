using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record AllRoleQuery() : IRequest<ErrorOr<List<AllRoleResult>?>>;
