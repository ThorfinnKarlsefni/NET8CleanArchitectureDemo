using LogisticsManagementSystem.Application;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Api;
[AllowAnonymous]
public class MenuController : ApiController
{
    private readonly IMediator _mediator;

    public MenuController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("auth/menu")]
    public async Task<IActionResult> Create(CreateMenuCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpDelete("auth/menu/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteMenuCommand(id);
        var result = await _mediator.Send(command);
        return result.Match(
           _ => NoContent(),
           Problem);
    }

    [HttpPut("auth/menu/{id}")]
    public async Task<IActionResult> Update(int id, UpdateMenuCommand command)
    {
        var updateCommand = command with { Id = id };
        var result = await _mediator.Send(updateCommand);
        return result.Match(
        _ => NoContent(),
        Problem);
    }

    [HttpGet("auth/menu")]
    public async Task<IActionResult> List()
    {
        var result = await _mediator.Send(new ListMenusQuery());
        return result.Match(
          _ => Ok(result.Value),
          Problem);
    }

    [HttpGet("auth/menu/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetMenuQuery(id);
        var result = await _mediator.Send(query);
        return result.Match(
          _ => Ok(result.Value),
          Problem);
    }
}
