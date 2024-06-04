using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class CustomersRepository(
    AppDbContext _dbContext
) : ICustomerRepository
{
    public async Task<List<Customer>> GetCustomersByUserListAndCompanyIdsAsync(Guid UserId, Guid CompanyId, CancellationToken cancellationToken)
    {
        return await _dbContext.Customers
                .Where(x => x.UserId == UserId)
                .Where(x => x.CompanyId == CompanyId)
                .ToListAsync(cancellationToken);
    }
}
