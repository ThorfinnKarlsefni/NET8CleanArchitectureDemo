using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record GetUserQuery(string Id) : IRequest<ErrorOr<GetUserResult>>;