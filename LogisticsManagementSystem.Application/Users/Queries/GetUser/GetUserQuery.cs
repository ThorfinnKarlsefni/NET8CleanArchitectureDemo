using ErrorOr;
using LogisticsManagementSystem.Application.Common.Security.Permissions;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Permission.User.Get, Policies = Policy.SelfOrAdmin)]
public record GetUserQuery(Guid Id) : IAuthorizeAbleRequest<ErrorOr<GetUserResult>>;