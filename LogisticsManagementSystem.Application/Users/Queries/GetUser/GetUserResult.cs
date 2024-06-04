namespace LogisticsManagementSystem.Application;

public record GetUserResult(
    string Name,
    string? Avatar,
    List<GetRolesResult> Roles);