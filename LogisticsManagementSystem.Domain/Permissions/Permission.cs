namespace LogisticsManagementSystem.Domain;

public class Permission : Entity<int>
{
    public int? ParentId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string HttpPath { get; private set; } = string.Empty;
    public string? HttpMethod { get; private set; } = string.Empty;
    public ICollection<Permission>? Children { get; private set; }

    public Permission(int? parentId, string name, string httpPath, string? httpMethod)
    {
        ParentId = parentId;
        Name = name;
        HttpPath = httpPath;
        HttpMethod = httpMethod;
    }
}
