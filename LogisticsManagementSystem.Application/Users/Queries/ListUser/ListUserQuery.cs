using ErrorOr;
using LogisticsManagementSystem.Application.Common.Security.Permissions;


namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Permission.User.Get, Policies = Policy.SelfOrAdmin)]
public record ListUserQuery(
    int PageNumber,
    int PageSize,
    string? SearchKeyword,
    bool Disable
    ) : IAuthorizeAbleRequest<ErrorOr<ListUserResult>>;