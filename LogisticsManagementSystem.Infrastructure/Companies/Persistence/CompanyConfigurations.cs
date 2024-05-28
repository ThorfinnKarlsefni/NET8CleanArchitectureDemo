using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsManagementSystem.Infrastructure;

public class CompanyConfigurations : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");
        builder.Property(x => x.Name).HasColumnType("varchar(256)");
        builder.Property(x => x.PhoneNumber).HasColumnType("varchar(256)");
        builder.Property(x => x.Address).HasColumnType("varchar(256)");
        builder.Property(x => x.CreatedAt).HasColumnType("timestamp");
        builder.Property(x => x.UpdatedAt).HasColumnType("timestamp");
        builder.Property(x => x.DeletedAt).HasColumnType("timestamp");
    }
}
