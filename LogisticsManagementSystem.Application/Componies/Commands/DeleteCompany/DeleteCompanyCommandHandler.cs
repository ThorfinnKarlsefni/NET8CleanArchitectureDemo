using ErrorOr;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class DeleteCompanyCommandHandler(
    ICompanyRepository _companyRepository
) : IRequestHandler<DeleteCompanyCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteCompanyCommand command, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.FindByIdAsync(command.CompanyId, cancellationToken);

        if (company is null)
        {
            return Error.NotFound(description: "公司不存在");
        }

        await _companyRepository.RemoveAsync(company, cancellationToken);

        return Result.Deleted;
    }
}
