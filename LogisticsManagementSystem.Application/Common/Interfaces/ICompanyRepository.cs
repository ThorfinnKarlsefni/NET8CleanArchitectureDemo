using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface ICompanyRepository
{
    Task CreateAsync(Company company, CancellationToken cancellationToken);
    Task<(List<Company> companies, long totalCount)> GetListCompanyAsync(int pageNumber, int pageSize, string? searchKeyword,
    bool? IsDisable, CancellationToken cancellationToken);
}
