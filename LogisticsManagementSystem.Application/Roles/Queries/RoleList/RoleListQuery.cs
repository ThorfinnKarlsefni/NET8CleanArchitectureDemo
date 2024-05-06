using ErrorOr;
using LogisticsManagementSystem.Application.Common.Security.Permissions;
using MediatR;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Permission.Role.Get, Policies = Policy.SelfOrAdmin)]
public record RoleListQuery(
    int PageNumber,
    int PageSize,
    string? SearchKeyword,
    Guid UserId
) : IAuthorizeAbleRequest<ErrorOr<RoleListResult>>;
