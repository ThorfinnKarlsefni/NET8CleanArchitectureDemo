
namespace LogisticsManagementSystem.Domain;

public class Menu : Entity
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string? Icon { get; set; } = string.Empty;
    public string? Component { get; set; } = string.Empty;
    public int Sort { get; private set; }
    public bool Visibility { get; private set; } = true;
    public Menu(int? parentId, string name, string path, string? icon, string? component, bool visibility)
    {
        ParentId = parentId;
        Name = name;
        Path = path;
        Icon = icon;
        Component = component;
        Visibility = visibility;
    }
    public void UpdateMenu(int? parentId, string name, string path, string? component, string? icon, int? sort, bool? visibility)
    {
        ParentId = parentId;
        Name = name;
        Path = path;
        Component = component;
        Icon = icon;
        Sort = sort ?? 0;
        Visibility = visibility ?? false;
    }

    public void UpdateSort(int? parentId, int sort)
    {
        ParentId = parentId;
        Sort = sort;
    }

    public void HideOrShow(bool visibility)
    {
        Visibility = visibility ? false : true;
    }

    public Menu()
    {

    }
}
