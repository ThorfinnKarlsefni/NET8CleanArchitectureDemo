using LogisticsManagementSystem.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Api;

[Authorize]
public class RoleController(IMediator _mediator) : ApiController
{
    [HttpGet("roles")]
    public async Task<IActionResult> GetRoles()
    {
        var result = await _mediator.Send(new GetRolesQuery());
        return result.Match(
            roles => Ok(roles),
        Problem);
    }

    [HttpGet("roles/list")]
    public async Task<IActionResult> GetRoleList(int pageNumber, int pageSize, string? searchKeyword)
    {
        var result = await _mediator.Send(new ListRoleQuery
       (pageNumber, pageSize, searchKeyword));
        return result.Match(
            roleList => Ok(roleList),
        Problem);
    }

    [HttpGet("role/{roleId}/permissions")]
    public async Task<IActionResult> GetRolePermissions(Guid roleId)
    {
        var query = new GetRolePermissionsQuery(roleId);
        var result = await _mediator.Send(query);
        return result.Match(
            permissions => Ok(permissions),
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

    [HttpPut("role/{roleId}")]
    public async Task<IActionResult> UpdateRole(Guid roleId, UpdateRoleCommand command)
    {
        var updateCommand = command with { RoleId = roleId };
        var result = await _mediator.Send(updateCommand);
        return result.Match(
            _ => NoContent(),
        Problem);
    }

    [HttpPut("role/{roleId}/permissions")]
    public async Task<IActionResult> UpdateRoleWithPermissions(Guid roleId, UpdateRolePermissionsCommand command)
    {
        var updateRolePermissionsCommand = command with { RoleId = roleId };
        var result = await _mediator.Send(updateRolePermissionsCommand);
        return result.Match(
            _ => NoContent(),
        Problem);
    }

    [HttpDelete("role/{roleId}")]
    public async Task<IActionResult> DeleteRole(Guid roleId)
    {
        var deleteCommand = new DeleteRoleCommand(roleId);
        var result = await _mediator.Send(deleteCommand);
        return result.Match(
            _ => NoContent(),
        Problem);
    }

}
