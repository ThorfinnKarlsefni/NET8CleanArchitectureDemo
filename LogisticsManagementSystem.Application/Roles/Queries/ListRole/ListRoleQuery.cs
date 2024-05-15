using ErrorOr;
using LogisticsManagementSystem.Application.Common.Security.Permissions;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Permission.Role.Get, Policies = Policy.SelfOrAdmin)]
public record ListRoleQuery(
    int PageNumber,
    int PageSize,
    string? SearchKeyword
) : IAuthorizeAbleRequest<ErrorOr<ListRoleResult>>;
