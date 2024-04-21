using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record UserListQuery(
    int PageNumber,
    int PageSize,
    string? SearchKeyword,
    bool? Disable
    ) : IRequest<ErrorOr<UserListResult?>>;