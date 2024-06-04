using ErrorOr;

namespace LogisticsManagementSystem.Domain;

public class Role : Entity
{
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public string NormalizedName { get; private set; }
    public List<UserRole> UserRoles { get; private set; } = [];
    public List<RoleMenus> RoleMenus { get; set; } = [];
    public List<RolePermissions> RolePermissions { get; private set; } = [];
    public List<RoleCompanies> RoleCompanies { get; private set; } = new List<RoleCompanies>();


    public Role(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        NormalizedName = name.ToUpper();
    }

    public void Update(string name)
    {
        Name = name;
        NormalizedName = name.ToUpper();
        SetUpdateAt();
    }

    public ErrorOr<Success> SetRoleMenus(Guid roleId, List<int> menuIds)
    {
        var menuRoleRelations = menuIds.Select(menuId => new RoleMenus(menuId, roleId)).ToList();

        if (menuRoleRelations.Any())
        {
            _domainEvents.Add(new MenuSetEvent(menuRoleRelations));
        }

        return Result.Success;
    }


    public ErrorOr<Success> DeleteRoleMenus(Guid roleId)
    {
        if (roleId == Guid.Empty)
        {
            return Error.Validation(description: "事件参数错误");
        }

        _domainEvents.Add(new MenuDeleteEvent(roleId));
        return Result.Success;
    }
}
