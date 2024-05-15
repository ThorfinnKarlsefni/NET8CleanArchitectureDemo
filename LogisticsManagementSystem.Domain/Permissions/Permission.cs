
namespace LogisticsManagementSystem.Domain;

public class Permission : Entity
{
    public int Id { get; set; }
    public int? ParentId { get; private set; }
    public string Name { get; private set; } = string.Empty;

    public string? Controller { get; private set; }
    public string? Action { get; private set; }
    public string? Method { get; private set; }
    public int Sort { get; private set; }

    public Permission(int? parentId, string name, string? controller, string? action, string? method)
    {
        ParentId = parentId;
        Name = name;
        Controller = controller;
        Action = action;
        Method = method;
    }

    public void Update(int? parentId, string name, string? controller, string? action, string? method)
    {
        ParentId = parentId;
        Name = name;
        Controller = controller;
        Action = action;
        Method = method;
    }

    public void UpdateSort(int? parentId, int sort)
    {
        ParentId = parentId;
        Sort = sort;
    }
}
