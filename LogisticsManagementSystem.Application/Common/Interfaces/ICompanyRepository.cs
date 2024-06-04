using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface ICompanyRepository
{
    Task<(List<Company> companies, long totalCount)> GetListCompanyAsync(
        int pageNumber,
        int pageSize,
        string? searchKeyword,
        Dictionary<string, string> Sorters,
        Dictionary<string, List<string>> Filters,
        CancellationToken cancellationToken);
    Task<List<Company>> GetCompanies(CancellationToken cancellationToken);
    Task<Company?> FindByIdAsync(Guid CompanyId, CancellationToken cancellationToken);
    Task CreateAsync(Company company, CancellationToken cancellationToken);
    Task UpdateAsync(Company company, CancellationToken cancellationToken);
    Task RemoveAsync(Company company, CancellationToken cancellationToken);
}
