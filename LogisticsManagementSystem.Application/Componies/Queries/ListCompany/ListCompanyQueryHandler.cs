using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class ListCompanyQueryHandler(ICompanyRepository _companyRepository) : IRequestHandler<ListCompanyQuery, ErrorOr<ListCompanyResult>>
{
    public async Task<ErrorOr<ListCompanyResult>> Handle(ListCompanyQuery query, CancellationToken cancellationToken)
    {
        var (companies, totalCount) = await _companyRepository.GetListCompanyAsync(
            query.PageNumber,
            query.PageSize,
            query.SearchKeyword,
            query.Sorters,
            query.Filters,
            cancellationToken
        );

        return new ListCompanyResult(companies, totalCount);
    }
}
