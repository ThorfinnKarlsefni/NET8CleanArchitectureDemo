namespace LogisticsManagementSystem.Domain;

public class Permission : Entity<int>
{
    public int? ParentId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string HttpPath { get; private set; } = string.Empty;
    public string HttpMethod { get; private set; } = string.Empty;
    public ICollection<Permission>? Children { get; private set; }
}
