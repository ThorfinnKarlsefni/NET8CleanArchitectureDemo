using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public record GetCompaniesQueryHandler(
    ICompanyRepository _companyRepository
) : IRequestHandler<GetCompaniesQuery, ErrorOr<List<Company>>>
{
    public async Task<ErrorOr<List<Company>>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
    {
        return await _companyRepository.GetCompanies(cancellationToken);

    }
}

