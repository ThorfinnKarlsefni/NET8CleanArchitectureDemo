namespace LogisticsManagementSystem.Domain;

public class RoleCompanies
{
    public Guid RoleId { get; set; }
    public Role Role { get; set; } = null!;
    public Guid CompanyId { get; set; }
    public Company Company { get; set; } = null!;

    public RoleCompanies(Guid roleId, Guid companyId)
    {
        RoleId = roleId;
        CompanyId = companyId;
    }
}
