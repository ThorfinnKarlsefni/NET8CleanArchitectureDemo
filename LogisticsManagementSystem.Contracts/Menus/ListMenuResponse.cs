namespace LogisticsManagementSystem.Contracts;

public class ListMenuResponse
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string? Component { get; set; }
    public int? Sort { get; set; }
    public bool Visibility { get; set; }
    public List<ListMenuResponse>? Children { get; set; }
}