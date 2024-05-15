using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsManagementSystem.Infrastructure;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");
        builder.Property(x => x.Name).HasColumnType("varchar(256)");
        builder.Property(x => x.Path).HasColumnType("varchar(256)");
        builder.Property(x => x.Icon).HasColumnType("varchar(256)");
        builder.Property(x => x.Controller).HasColumnType("varchar(256)");
        builder.Property(x => x.Component).HasColumnType("varchar(256)");
        builder.Property(r => r.CreatedAt).HasColumnType("timestamp");
        builder.Property(r => r.UpdatedAt).HasColumnType("timestamp");
        builder.Property(r => r.DeletedAt).HasColumnType("timestamp");
    }
}