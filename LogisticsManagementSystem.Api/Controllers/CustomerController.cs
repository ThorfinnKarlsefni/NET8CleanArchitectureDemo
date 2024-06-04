
using LogisticsManagementSystem.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Api;


public class CustomerController(
    ISender _sender,
    ICurrentUserProvider _currentUserProvider
    ) : ApiController
{

    [HttpGet("customers/{companyId}")]
    public async Task<IActionResult> GetCustomers(Guid companyId)
    {
        var user = _currentUserProvider.GetCurrentUser();
        var result = await _sender.Send(new GetCustomersQuery(user.Id, companyId, user.CompanyIds));
        return result.Match(
            customers => Ok(customers),
        Problem);
    }
}
