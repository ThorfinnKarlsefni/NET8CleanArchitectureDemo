using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record ListRoleQuery(
    int PageNumber,
    int Pagesize,
    string SearchKeyword
) : IRequest<ErrorOr<ListRoleResult>>;
