using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class CreateCompanyCommandHandler(ICompanyRepository _companyRepository) : IRequestHandler<CreateCompanyCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
    {
        var company = new Company(command.Name, command.PhoneNumber, command.Address, command.IsDisable);
        await _companyRepository.CreateAsync(company, cancellationToken);
        return Result.Created;
    }
}
