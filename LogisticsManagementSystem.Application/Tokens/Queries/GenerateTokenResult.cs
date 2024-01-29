namespace LogisticsManagementSystem.Application;

public record GenerateTokenResult(
    string? Name,
    string? Avatar,
    string Token
);