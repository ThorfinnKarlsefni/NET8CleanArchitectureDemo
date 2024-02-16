using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record GetCurrentUserQuery(string UserId) : IRequest<ErrorOr<CurrentUserResult>>;
