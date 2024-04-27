
namespace LogisticsManagementSystem.Domain;

public class Permission : Entity<int>
{
    public int? ParentId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Slug { get; private set; } = string.Empty;
    public string? Path { get; private set; } = string.Empty;
    public string? Action { get; private set; } = string.Empty;
    public string? Method { get; private set; } = string.Empty;
    public int Sort { get; private set; }
    public ICollection<Permission>? Children { get; private set; }

    public Permission(int? parentId, string name, string? slug, string? path, string? action, string? method)
    {
        ParentId = parentId;
        Name = name;
        Slug = slug;
        Path = path;
        Action = action;
        Method = method;
    }

    public void Update(int? parentId, string name, string? slug, string? path, string? action, string? method)
    {
        ParentId = parentId;
        Name = name;
        Slug = slug;
        Path = path;
        Action = action;
        Method = method;
    }

    public void UpdateSort(int? parentId, int sort)
    {
        ParentId = parentId;
        Sort = sort;
    }
}
