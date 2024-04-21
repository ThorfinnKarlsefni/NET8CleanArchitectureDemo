using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record RoleListQuery(
    int PageNumber,
    int PageSize,
    string? SearchKeyword
) : IRequest<ErrorOr<RoleListResult>>;
