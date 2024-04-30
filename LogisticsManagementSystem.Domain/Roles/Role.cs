using ErrorOr;
using Microsoft.AspNetCore.Identity;

namespace LogisticsManagementSystem.Domain;

public class Role : IdentityRole<Guid>, IEntity
{
    public string? Slug { get; private set; }
    public DateTime CreatedAt { get; private init; }
    public DateTime UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public List<UserRole> UserRoles { get; private set; } = [];
    public List<MenuRole> MenuRoles { get; set; } = [];

    protected readonly List<IDomainEvent> _domainEvents = [];

    public Role(string Name) : base(Name)
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = CreatedAt;
    }

    public List<IDomainEvent> PopDomainEvents()
    {
        var copy = _domainEvents.ToList();
        _domainEvents.Clear();
        return copy;
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

    public void SetUpdateAt()
    {
        UpdatedAt = DateTime.Now;
    }

    public void SetDeletedAt()
    {
        DeletedAt = DateTime.Now;
    }
}
