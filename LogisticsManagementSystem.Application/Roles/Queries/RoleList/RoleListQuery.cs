using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

[Authorize(Permissions = Common.Security.Permissions.Permission.Role.Get, Policies = Policy.SelfOrAdmin)]
public record RoleListQuery(
    int PageNumber,
    int PageSize,
    string? SearchKeyword
) : IRequest<ErrorOr<RoleListResult>>;
