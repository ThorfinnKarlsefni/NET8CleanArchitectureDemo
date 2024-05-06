using LogisticsManagementSystem.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Api;

[Authorize]
public class RoleController : ApiController
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("roles/all")]
    public async Task<IActionResult> GetAllRoles()
    {
        var result = await _mediator.Send(new AllRoleQuery());
        return result.Match(
            _ => Ok(result.Value),
            Problem);
    }

    [HttpGet("roles/list")]
    public async Task<IActionResult> GetRoleList(int pageNumber, int pageSize, string? searchKeyword)
    {
        var result = await _mediator.Send(new RoleListQuery
       (pageNumber, pageSize, searchKeyword));
        return result.Match(
            _ => Ok(result.Value),
            Problem);
    }

    [HttpPost("role")]
    public async Task<IActionResult> CreateRole(CreateRoleCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpPut("role/{id}")]
    public async Task<IActionResult> UpdateRole(Guid id, UpdateRoleCommand command)
    {
        var updateCommand = command with { RoleId = id };
        var result = await _mediator.Send(updateCommand);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpDelete("role/{id}")]
    public async Task<IActionResult> DeleteRole(Guid id)
    {
        var deleteCommand = new DeleteRoleCommand(id);
        var result = await _mediator.Send(deleteCommand);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

}
