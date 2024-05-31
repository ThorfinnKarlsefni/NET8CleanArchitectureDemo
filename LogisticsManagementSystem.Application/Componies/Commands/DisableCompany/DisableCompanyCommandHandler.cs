using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class DisableCompanyCommandHandler(
    ICompanyRepository _companyRepository
) : IRequestHandler<DisableCompanyCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(DisableCompanyCommand command, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.FindByIdAsync(command.CompanyId, cancellationToken);
        if (company is null)
        {
            return Error.NotFound(description: "公司不存在");
        }
        company.Disable(command.IsDisable);
        await _companyRepository.UpdateAsync(company, cancellationToken);
        return Result.Updated;
    }
}
