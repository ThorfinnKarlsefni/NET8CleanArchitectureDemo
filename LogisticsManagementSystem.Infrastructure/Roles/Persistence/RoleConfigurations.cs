using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsManagementSystem.Infrastructure;

public class RoleConfigurations : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        builder.Property(r => r.NormalizedName).HasColumnType("varchar(256)");
        builder.Property(r => r.CreatedAt).HasColumnType("timestamp");
        builder.Property(r => r.UpdatedAt).HasColumnType("timestamp");
        builder.Property(r => r.DeletedAt).HasColumnType("timestamp");
    }
}
