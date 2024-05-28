using LogisticsManagementSystem.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Api;

public class CompanyController(ISender _sender) : ApiController
{
    [HttpGet("companies")]
    public async Task<IActionResult> GetCompanyList(int pageNumber, int pageSize, string? searchKeyword, bool? isDisable)
    {
        var result = await _sender.Send(new ListCompanyQuery(pageNumber, pageSize, searchKeyword, isDisable));
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
}
