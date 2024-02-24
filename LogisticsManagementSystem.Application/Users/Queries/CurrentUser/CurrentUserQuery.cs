using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record CurrentUserQuery(string UserId) : IRequest<ErrorOr<CurrentUserResult>>;
