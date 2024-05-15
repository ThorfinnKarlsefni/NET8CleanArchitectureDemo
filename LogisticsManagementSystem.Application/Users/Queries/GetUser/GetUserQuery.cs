using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record GetUserQuery(Guid Id) : IRequest<ErrorOr<GetUserResult>>;