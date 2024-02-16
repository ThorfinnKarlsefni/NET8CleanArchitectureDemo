﻿
namespace LogisticsManagementSystem.Domain;

public class Menu : Entity<int>
{
    public int? ParentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string? Icon { get; set; } = string.Empty;
    public string? Component { get; set; } = string.Empty;
    public int Rank { get; private set; }
    public bool HideMenu { get; private set; } = false;
    public List<Menu>? Children { get; set; } = new List<Menu>();

    public Menu(int? parentId, string name, string path, string? icon, string? component, bool hideMenu)
    {
        ParentId = parentId;
        Name = name;
        Path = path;
        Icon = icon;
        Component = component;
        HideMenu = hideMenu;
    }
    public void UpdateMenu(int? parentId, string name, string path, string? component, string? icon, int? rank, bool? hideMenu)
    {
        ParentId = parentId;
        Name = name;
        Path = path;
        Component = component ?? string.Empty;
        Icon = icon;
        Rank = rank ?? 0;
        HideMenu = hideMenu ?? false;
    }

    public Menu()
    {

    }
}
