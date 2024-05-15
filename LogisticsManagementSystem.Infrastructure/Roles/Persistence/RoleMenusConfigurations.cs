using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsManagementSystem.Infrastructure;

public class RoleMenusConfigurations : IEntityTypeConfiguration<RoleMenus>
{
    public void Configure(EntityTypeBuilder<RoleMenus> builder)
    {
        builder.ToTable("RoleMenus");
        builder.HasKey(x => new { x.MenuId, x.RoleId });
    }
}
