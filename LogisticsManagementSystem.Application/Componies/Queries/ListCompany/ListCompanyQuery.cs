using ErrorOr;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Common.Security.Permissions.Permission.Company.Get, Policies = Policy.SelfOrAdmin)]
public record ListCompanyQuery(
    int PageNumber,
    int PageSize,
    string? SearchKeyword,
    bool? IsDisable
) : IAuthorizeAbleRequest<ErrorOr<ListCompanyResult>>;