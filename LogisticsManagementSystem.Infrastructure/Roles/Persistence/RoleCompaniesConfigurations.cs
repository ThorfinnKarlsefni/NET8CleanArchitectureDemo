using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsManagementSystem.Infrastructure;

public class RoleCompaniesConfigurations : IEntityTypeConfiguration<RoleCompanies>
{
    public void Configure(EntityTypeBuilder<RoleCompanies> builder)
    {
        builder.ToTable("RoleCompanies");
        builder.HasKey(r => new
        {
            r.RoleId,
            r.CompanyId
        });
    }
}
