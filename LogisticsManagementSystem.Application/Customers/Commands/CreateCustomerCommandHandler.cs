using ErrorOr;
using LogisticsManagementSystem.Domain;
using MediatR;

namespace LogisticsManagementSystem.Application;

public class CreateCustomerCommandHandler(
    ICustomerRepository _customerRepository
) : IRequestHandler<CreateCustomerCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            CompanyId = command.CompanyId,
            Name = command?.Name,
            PhoneNumber = command?.Telphone,
            AppName = command?.App_name,
            ModuleName = command?.Module_name,
            AdvName = command?.Adv_name,
            Url = command?.External_url,
        };

        await _customerRepository.AddAsync(customer, cancellationToken);

        return Result.Created;
    }
}
