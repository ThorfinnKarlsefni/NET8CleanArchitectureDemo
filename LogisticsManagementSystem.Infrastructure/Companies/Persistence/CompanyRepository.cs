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

    public async Task<Company?> FindByIdAsync(Guid CompanyId, CancellationToken cancellationToken)
    {
        return await _dbContext.Companies
            .Where(x => x.Id == CompanyId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<Company>> GetCompanies(CancellationToken cancellationToken)
    {
        return await _dbContext.Companies
            .Where(x => x.IsDisable == false)
            .ToListAsync();
    }

    public async Task<(List<Company> companies, long totalCount)> GetListCompanyAsync(int pageNumber, int pageSize, string? searchKeyword, Dictionary<string, string> sorters, Dictionary<string, List<string>> filters, CancellationToken cancellationToken)
    {
        IQueryable<Company> query = _dbContext.Companies.AsQueryable();

        if (!string.IsNullOrEmpty(searchKeyword))
        {
            query = query.Where(x => x.Name.Contains(searchKeyword.Trim()));
        }

        if (sorters != null && sorters.Any())
        {
            foreach (var sort in sorters)
            {
                switch (sort.Key)
                {
                    case "createdAt":
                        query = sort.Value == "ascend" ?
                        query.OrderBy(x => x.CreatedAt) :
                        query.OrderByDescending(x => x.CreatedAt);
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            query = query.OrderByDescending(x => x.CreatedAt);
        }

        if (filters != null && filters.Any())
        {
            foreach (var filter in filters)
            {
                if (filter.Value == null || filter.Value.Count == 0) continue;

                switch (filter.Key)
                {
                    case "isDisable":
                        var isDisableValues = filter.Value.Select(x => bool.Parse(x)).ToList();
                        if (isDisableValues.Any())
                        {
                            query = query.Where(x => isDisableValues.Contains(x.IsDisable));
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        var companies = await query
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var totalCount = await query.LongCountAsync();
        return (companies, totalCount);
    }

    public async Task RemoveAsync(Company company, CancellationToken cancellationToken)
    {
        _dbContext.Companies.Remove(company);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Company company, CancellationToken cancellationToken)
    {
        _dbContext.Companies.Update(company);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
