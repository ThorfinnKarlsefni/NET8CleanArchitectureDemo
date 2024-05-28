using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record GetUserQuery(Guid UserId) : IRequest<ErrorOr<GetUserResult>>;