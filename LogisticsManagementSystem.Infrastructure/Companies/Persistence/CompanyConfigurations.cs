using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsManagementSystem.Infrastructure;

public class CompanyConfigurations : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");
        builder.Property(c => c.Name).HasColumnType("varchar(256)");
        builder.Property(r => r.CreatedAt).HasColumnType("timestamp");
        builder.Property(r => r.UpdatedAt).HasColumnType("timestamp");
        builder.Property(r => r.DeletedAt).HasColumnType("timestamp");

        // builder.HasOne(c => c.CreateUser)
        //     .WithMany()
        //     .HasForeignKey(c => c.CreateUserId)
        //     .OnDelete(DeleteBehavior.NoAction);

        // builder.HasOne(c => c.UpdateUser)
        //     .WithMany()
        //     .HasForeignKey(c => c.UpdateUserId)
        //     .OnDelete(DeleteBehavior.NoAction);
    }
}
