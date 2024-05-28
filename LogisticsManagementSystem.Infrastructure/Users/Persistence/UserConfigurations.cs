using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsManagementSystem.Infrastructure;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.Property(u => u.Name).HasColumnType("varchar(256)");
        builder.Property(u => u.Avatar).HasColumnType("varchar(256)");
        builder.Property(u => u.PasswordHash).HasColumnType("varchar(256)");
        builder.Property(u => u.Email).HasColumnType("varchar(256)");
        builder.Property(u => u.PhoneNumber).HasColumnType("varchar(256)");
        builder.Property(u => u.SecurityStamp).HasColumnType("varchar(256)");
        builder.Property(u => u.LockoutEnd).HasColumnType("timestamp");
        builder.Property(u => u.CreatedAt).HasColumnType("timestamp");
        builder.Property(u => u.UpdatedAt).HasColumnType("timestamp");
        builder.Property(u => u.DeletedAt).HasColumnType("timestamp");

        builder.HasOne(u => u.Company)
            .WithOne()
            .HasForeignKey<User>(u => u.CompanyId);
    }
}
