namespace LogisticsManagementSystem.Contracts;

public class GetUserListRequest
{
    public int PageSize { get; set; } = 10;
    public int PageNumber { get; set; } = 1;
    public string? Search { get; set; }
}
