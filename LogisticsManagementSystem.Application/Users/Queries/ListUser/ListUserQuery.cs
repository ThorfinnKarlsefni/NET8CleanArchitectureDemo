using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Common.Security.Permissions.Permission.User.Get, Policies = Policy.SelfOrAdmin)]
public record ListUserQuery(
    int PageNumber,
    int PageSize,
    string? SearchKeyword,
    bool Disable
    ) : IAuthorizeAbleRequest<ErrorOr<ListUserResult>>;