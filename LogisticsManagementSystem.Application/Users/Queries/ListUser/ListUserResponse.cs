using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public class ListUserResponse
{
    public string Name { get; set; } = string.Empty;
    public string? Avatar { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<string?> Roles { get; set; } = new List<string?>();
}
