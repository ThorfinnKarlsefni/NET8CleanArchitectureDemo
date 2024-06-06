using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace LogisticsManagementSystem.Infrastructure;

public class CustomersRepository(
    AppDbContext _dbContext
) : ICustomerRepository
{
    public async Task AddAsync(Customer customer, CancellationToken cancellationToken)
    {
        await _dbContext.Customers
                .AddAsync(customer, cancellationToken);
        await _dbContext.SaveChangesAsync();

    }

    public async Task<List<Customer>> GetCustomersByUserListAndCompanyIdsAsync(Guid? UserId, Guid CompanyId, CancellationToken cancellationToken)
    {
        IQueryable<Customer> query = _dbContext.Customers.AsQueryable();

        if (UserId != Guid.Empty)
        {
            query = query.Where(x => x.UserId == UserId);
        }

        return await query
                .Where(x => x.CompanyId == CompanyId)
                .ToListAsync(cancellationToken);
    }
}
