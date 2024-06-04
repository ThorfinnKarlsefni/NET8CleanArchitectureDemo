using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class UpdateRoleCompaniesCommandHandler(
    IRoleCompaniesRepository _roleCompaniesRepository
) : IRequestHandler<UpdateRoleCompaniesCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateRoleCompaniesCommand command, CancellationToken cancellationToken)
    {
        await _roleCompaniesRepository.DeleteRangeAsync(command.RoleId, cancellationToken);

        if (command.CompanyIds.Any())
        {
            var roleCompanies = new List<RoleCompanies>();
            foreach (var companyId in command.CompanyIds)
            {
                var roleCompany = new RoleCompanies(command.RoleId, companyId);
                roleCompanies.Add(roleCompany);
            }

            await _roleCompaniesRepository.AddRangeAsync(roleCompanies, cancellationToken);
        }

        return Result.Updated;
    }
}
