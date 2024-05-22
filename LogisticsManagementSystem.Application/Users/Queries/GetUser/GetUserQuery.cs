using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

// [Authorize(Permissions = Permission.User.Get, Policies = Policy.SelfOrAdmin)]
public record GetUserQuery(Guid UserId) : IRequest<ErrorOr<GetUserResult>>;