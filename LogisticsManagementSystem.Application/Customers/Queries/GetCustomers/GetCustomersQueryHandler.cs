using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GetCustomersQueryHandler(
    ICustomerRepository _customerRepository
) : IRequestHandler<GetCustomersQuery, ErrorOr<List<Customer>>>
{
    public async Task<ErrorOr<List<Customer>>> Handle(GetCustomersQuery query, CancellationToken cancellationToken)
    {

        if (query.CompanyIds.Any())
        {
            if (query.CompanyIds.Contains(query.RequestCompanyId))
            {
                return await _customerRepository.GetCustomersByUserListAndCompanyIdsAsync(query.UserId, query.RequestCompanyId, cancellationToken);
            }
            else
            {
                return Error.Forbidden(description: "没有数据权限");
            }
        }

        return new List<Customer>();
    }
}
