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
        builder.Property(u => u.TokenVersion).HasDefaultValue(0);

    }
    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");
            builder.HasKey(ur => new { ur.UserId, ur.RoleId });

            builder.HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

            builder.HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);
        }
    }
}
