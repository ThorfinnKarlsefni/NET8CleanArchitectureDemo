namespace LogisticsManagementSystem.Application;

public record GetUserResult(
    string? Company,
    string Name,
    string? Avatar,
    List<string> Roles);