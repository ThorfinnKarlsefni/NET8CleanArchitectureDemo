using LogisticsManagementSystem.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;
public class AppDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{

    public DbSet<Menu> Menus { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<MenuRole> MenuRoles { get; set; }
    public DbSet<Company> Companies { get; set; }
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
        SeedData.Seed(builder);
    }
}
