namespace LogisticsManagementSystem.Contracts;

public record GetUserListRequest(
    int PageNumber,
    int PageSize,
    string? SearchKeyword,
    bool? Disable
);

