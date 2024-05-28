using LogisticsManagementSystem.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;
public class AppDbContext(DbContextOptions options, IHttpContextAccessor _httpContextAccessor, IPublisher _publisher) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<RoleMenus> RoleMenus { get; set; }
    public DbSet<RolePermissions> RolePermissions { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Company> Companies { get; set; }

    public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var domainEvents = ChangeTracker.Entries<Entity>()
           .SelectMany(entry => entry.Entity.PopDomainEvents())
           .ToList();

        // if (IsUserWaitingOnline())
        // {
        //     AddDomainEventsToOfflineProcessingQueue(domainEvents);
        //     return await base.SaveChangesAsync(cancellationToken);
        // }

        await PublishDomainEvents(domainEvents);
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
        builder.Entity<UserRole>().HasQueryFilter(ur => !ur.User.IsDeleted && !ur.Role.IsDeleted);
        builder.Entity<Menu>().HasQueryFilter(x => !x.IsDeleted);
        builder.Entity<Role>().HasQueryFilter(x => !x.IsDeleted);
        builder.Entity<RoleMenus>().HasQueryFilter(mr => !mr.Role.IsDeleted && !mr.Menu.IsDeleted);
        builder.Entity<RolePermissions>().HasQueryFilter(pr => !pr.Role.IsDeleted && !pr.Role.IsDeleted);
        builder.Entity<Permission>().HasQueryFilter(x => !x.IsDeleted);
        builder.Entity<Company>().HasQueryFilter(x => !x.IsDeleted);

        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
    }

    private bool IsUserWaitingOnline() => _httpContextAccessor.HttpContext is not null;
    private async Task PublishDomainEvents(List<IDomainEvent> domainEvents)
    {
        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent);
        }
    }

    private void AddDomainEventsToOfflineProcessingQueue(List<IDomainEvent> domainEvents)
    {
        Queue<IDomainEvent> domainEventsQueue = _httpContextAccessor.HttpContext!.Items.TryGetValue(EventualConsistencyMiddleware.DomainEventsKey, out var value) &&
            value is Queue<IDomainEvent> existingDomainEvents
                ? existingDomainEvents
                : new();

        domainEvents.ForEach(domainEventsQueue.Enqueue);
        _httpContextAccessor.HttpContext.Items[EventualConsistencyMiddleware.DomainEventsKey] = domainEventsQueue;
    }
}