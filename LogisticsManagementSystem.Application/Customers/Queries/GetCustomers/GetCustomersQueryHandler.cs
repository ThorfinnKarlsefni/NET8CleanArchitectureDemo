using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GetCustomersQueryHandler(
    ICustomerRepository _customerRepository,
    ICompanyRepository _companyRepository
) : IRequestHandler<GetCustomersQuery, ErrorOr<List<Customer>>>
{
    public async Task<ErrorOr<List<Customer>>> Handle(GetCustomersQuery query, CancellationToken cancellationToken)
    {
        if (query.Roles.Contains(CleanArchitecture.Application.Common.Security.Roles.Role.Admin))
        {
            var companyId = query?.RequestCompanyId;
            if (!companyId.HasValue)
            {
                var companyIds = await _companyRepository.GetCompanies(cancellationToken);
                companyId = companyIds.Select(x => x.Id).FirstOrDefault();
            }

            return await _customerRepository.GetCustomersByUserListAndCompanyIdsAsync(Guid.Empty, companyId.Value, cancellationToken);
        }

        if (query.CompanyIds.Any() && query.RequestCompanyId.HasValue)
        {
            if (query.CompanyIds.Contains(query.RequestCompanyId.Value))
            {
                return await _customerRepository.GetCustomersByUserListAndCompanyIdsAsync(query.UserId, query.RequestCompanyId.Value, cancellationToken);
            }
        }

        return new List<Customer>();
    }
}
