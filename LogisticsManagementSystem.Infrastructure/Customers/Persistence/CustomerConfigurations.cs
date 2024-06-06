using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsManagementSystem.Infrastructure;

public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasIndex(x => x.UserId);
        builder.HasIndex(x => x.CompanyId);

        builder.Property(x => x.Name).HasColumnType("varchar(256)");
        builder.Property(x => x.PhoneNumber).HasColumnType("varchar(256)");
        builder.Property(x => x.Remark).HasColumnType("varchar(256)");
        builder.Property(x => x.AppName).HasColumnType("varchar(256)");
        builder.Property(x => x.ModuleName).HasColumnType("varchar(256)");
        builder.Property(x => x.AdvName).HasColumnType("varchar(256)");
        builder.Property(x => x.ClueConvertStatus).HasColumnType("varchar(256)");
        builder.Property(x => x.Url).HasColumnType("text");
        builder.Property(x => x.Content).HasColumnType("text");
        builder.Property(x => x.ClueConvertStatus).HasColumnType("varchar(256)");
        builder.Property(x => x.AllocatedAt).HasColumnType("timestamp");
        builder.Property(x => x.CreatedAt).HasColumnType("timestamp");
        builder.Property(x => x.UpdatedAt).HasColumnType("timestamp");
        builder.Property(x => x.DeletedAt).HasColumnType("timestamp");
        builder.Property(x => x.DeletedAt).HasColumnType("timestamp");

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.Company)
            .WithMany()
            .HasForeignKey(x => x.CompanyId);
    }
}
