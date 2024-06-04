using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class GetRoleCompaniesQueryHandler(
    IRoleCompaniesRepository _roleCompaniesRepository
) : IRequestHandler<GetRoleCompaniesQuery, ErrorOr<List<Guid>>>
{
    public async Task<ErrorOr<List<Guid>>> Handle(GetRoleCompaniesQuery command, CancellationToken cancellationToken)
    {
        var roleCompanies = await _roleCompaniesRepository.GetListByRoleIdAsync(command.RoleId, cancellationToken);

        return roleCompanies.Select(x => x.Company.Id).ToList();
    }
}
