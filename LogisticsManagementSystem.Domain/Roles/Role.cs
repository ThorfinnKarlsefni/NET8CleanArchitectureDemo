using ErrorOr;

namespace LogisticsManagementSystem.Domain;

public class Role : Entity
{
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public string NormalizedName { get; private set; }
    public List<UserRole> UserRoles { get; private set; } = [];
    public List<RoleMenus> RoleMenus { get; set; } = [];
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
        var menuRoleRelations = menuIds.Select(menuId => new RoleMenus(menuId, roleId)).ToList();

        _domainEvents.Add(new RoleSetMenusEvent(menuRoleRelations));

        return Result.Success;
    }
}
