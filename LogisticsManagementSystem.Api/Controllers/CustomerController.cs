
using LogisticsManagementSystem.Application;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Api;

[AllowAnonymous]
public class CustomerController(
    ISender _sender,
    ICurrentUserProvider _currentUserProvider
    ) : ApiController
{

    [HttpGet("customers/{companyId?}")]
    public async Task<IActionResult> GetCustomers(Guid? companyId)
    {
        var user = _currentUserProvider.GetCurrentUser();
        var result = await _sender.Send(new GetCustomersQuery(companyId, user.Id, user.Roles, user.CompanyIds));
        return result.Match(
            customers => Ok(customers),
        Problem);
    }

    [HttpPost("customer/{companyId}")]
    public async Task<IActionResult> Create(Guid? companyId, CreateCustomerCommand command)
    {
        var result = await _sender.Send(command with { CompanyId = companyId });
        return result.Match(
            success => Ok(new
            {
                success = 1
            }),
        Problem);
    }
}
