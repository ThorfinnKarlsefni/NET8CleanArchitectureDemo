using System.Net.Quic;
using LogisticsManagementSystem.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Api;

public class CompanyController(ISender _sender) : ApiController
{
    [HttpPost("companies")]
    public async Task<IActionResult> GetCompanyList(ListCompanyQuery query)
    {
        var result = await _sender.Send(query);

        return result.Match(
            companies => Ok(companies),
        Problem);
    }

    [HttpPost("company")]
    public async Task<IActionResult> Create(CreateCompanyCommand command)
    {
        var result = await _sender.Send(command);
        return result.Match(
            _ => NoContent(),
        Problem);
    }

    [HttpPut("company/{companyId}")]
    public async Task<IActionResult> Update(Guid companyId, UpdateCompanyCommand command)
    {
        var result = await _sender.Send(command with { CompanyId = companyId });
        return result.Match(
            _ => NoContent(),
        Problem);
    }


    [HttpPut("company/{companyId}/disable")]
    public async Task<IActionResult> Disable(Guid companyId, DisableCompanyCommand command)
    {
        var result = await _sender.Send(command with { CompanyId = companyId });
        return result.Match(
            _ => NoContent(),
        Problem);
    }

    [HttpDelete("company/{companyId}")]
    public async Task<IActionResult> Delete(Guid companyId)
    {
        var result = await _sender.Send(new DeleteCompanyCommand(companyId));
        return result.Match(
            _ => NoContent(),
        Problem);
    }
}
