using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GetCompaniesByRoleQueryHandler
(
    ICompanyRepository _companyRepository
) : IRequestHandler<GetCompaniesByRoleQuery, ErrorOr<List<Company>>>
{
    public async Task<ErrorOr<List<Company>>> Handle(GetCompaniesByRoleQuery query, CancellationToken cancellationToken)
    {
        if (query.Role.Contains(CleanArchitecture.Application.Common.Security.Roles.Role.Admin))
        {
            return await _companyRepository.GetCompanies(cancellationToken);
        }

        return await _companyRepository.GetCompaniesByRoleAsync(query.CompanyIds, cancellationToken);
    }
}
