using System.ComponentModel.DataAnnotations;
using ErrorOr;

namespace LogisticsManagementSystem.Domain;

public class Role : Entity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string NormalizedName { get; private set; }
    public string? Slug { get; private set; }
    public List<UserRole> UserRoles { get; private set; } = [];
    public List<MenuRole> MenuRoles { get; set; } = [];
    public Role(string name)
    {
        Name = name;
        NormalizedName = name.ToUpper();
    }

    public void Update(string name)
    {
        Name = name;
        NormalizedName = name.ToUpper();
        SetUpdateAt();
    }

    public ErrorOr<Success> SetMenuRoleRelation(Guid roleId, List<int> menuIds)
    {
        var menuRoleRelations = menuIds.Select(menuId => new MenuRole
        {
            RoleId = roleId,
            MenuId = menuId
        }).ToList();

        _domainEvents.Add(new RoleMenuSetEvent(menuRoleRelations));

        return Result.Success;
    }
}
