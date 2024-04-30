﻿using LogisticsManagementSystem.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;
public class AppDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<MenuRole> MenuRoles { get; set; }
    public DbSet<Company> Companies { get; set; }

    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IPublisher _publisher;

    public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor, IPublisher publisher)
        : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
        _publisher = publisher;
    }

    public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var domainEvents = ChangeTracker.Entries<IEntity>()
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
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
        SeedData.Seed(builder);
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
