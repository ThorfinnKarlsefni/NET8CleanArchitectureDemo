using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsManagementSystem.Infrastructure;

public class PermissionConfigurations : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permissions");
        builder.Property(x => x.Name).HasColumnType("varchar(256)");
        builder.Property(x => x.HttpPath).HasColumnType("varchar(256)");
        builder.Property(x => x.HttpMethod).HasColumnType("varchar(256)");
        builder.Property(r => r.CreatedAt).HasColumnType("timestamp");
        builder.Property(r => r.UpdatedAt).HasColumnType("timestamp");
        builder.Property(r => r.DeletedAt).HasColumnType("timestamp");
        builder.Ignore(x => x.Children);
    }
}
