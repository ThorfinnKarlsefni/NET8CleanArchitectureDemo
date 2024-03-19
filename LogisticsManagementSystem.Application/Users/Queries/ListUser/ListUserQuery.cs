using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record ListUserQuery(
    int PageNumber,
    int PageSize,
    string? SearchKeyword,
    bool? Disable
    ) : IRequest<ErrorOr<ListUserResult?>>;