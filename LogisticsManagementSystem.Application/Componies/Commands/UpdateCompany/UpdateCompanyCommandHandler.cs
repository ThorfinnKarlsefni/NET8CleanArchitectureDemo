using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class UpdateCompanyCommandHandler(
    ICompanyRepository _companyRepository
) : IRequestHandler<UpdateCompanyCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateCompanyCommand command, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.FindByIdAsync(command.CompanyId, cancellationToken);

        if (company is null)
        {
            return Error.NotFound(description: "公司不存在");
        }
        company.Update(command.Name, command.PhoneNumber, command.Address, command.IsDisable);

        await _companyRepository.UpdateAsync(company, cancellationToken);

        return Result.Updated;
    }
}
