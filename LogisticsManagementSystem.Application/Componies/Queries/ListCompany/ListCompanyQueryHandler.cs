using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class ListCompanyQueryHandler(ICompanyRepository _companyRepository) : IRequestHandler<ListCompanyQuery, ErrorOr<ListCompanyResult>>
{
    public async Task<ErrorOr<ListCompanyResult>> Handle(ListCompanyQuery request, CancellationToken cancellationToken)
    {
        var (companies, totalCount) = await _companyRepository.GetListCompanyAsync(request.PageNumber, request.PageSize, request.SearchKeyword, request.IsDisable, cancellationToken);

        return new ListCompanyResult(companies, totalCount);
    }
}
