using System.Reflection.Metadata.Ecma335;
using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class CompanyRepository(AppDbContext _dbContext) : ICompanyRepository
{
    public async Task CreateAsync(Company company, CancellationToken cancellationToken)
    {
        await _dbContext.Companies.AddAsync(company);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<(List<Company> companies, long totalCount)> GetListCompanyAsync(int pageNumber, int pageSize, string? searchKeyword, bool? isDisable, CancellationToken cancellationToken)
    {
        IQueryable<Company> query = _dbContext.Companies;

        if (!string.IsNullOrEmpty(searchKeyword))
        {
            query = query.Where(x => x.Name.Contains(searchKeyword.Trim()));
        }

        if (isDisable.HasValue)
        {
            query = query.Where(x => x.IsDisable == isDisable.Value);
        }

        var totalCount = await query.LongCountAsync(cancellationToken);

        var companies = await query.OrderBy(x => x.CreatedAt)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        return (companies, totalCount);
    }
}
