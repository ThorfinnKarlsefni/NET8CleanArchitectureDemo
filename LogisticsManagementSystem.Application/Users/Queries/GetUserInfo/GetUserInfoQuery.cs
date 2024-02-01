using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record GetUserInfoQuery(string UserId) : IRequest<ErrorOr<UserInfoResult>>;
