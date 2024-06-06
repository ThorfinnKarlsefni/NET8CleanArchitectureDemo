using LogisticsManagementSystem.Domain;

namespace LogisticsManagementSystem.Application;

public interface ICustomerRepository
{
    Task<List<Customer>> GetCustomersByUserListAndCompanyIdsAsync(
        Guid? UserId,
        Guid CompanyId,
        CancellationToken cancellationToken
    );
    Task AddAsync(Customer customer, CancellationToken cancellationToken);
}
