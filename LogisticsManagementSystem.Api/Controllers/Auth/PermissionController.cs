using LogisticsManagementSystem.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Api;

public class PermissionController(
    ISender _sender
) : ApiController
{
    [HttpGet("permission/all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _sender.Send(new GetPermissionsQuery());
        return result.Match(
            permissions => Ok(permissions),
            Problem);
    }

    [HttpPost("permission")]
    public async Task<IActionResult> Create(CreatePermissionCommand command)
    {
        var result = await _sender.Send(command);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpPut("permission/{permissionId}")]
    public async Task<IActionResult> Update(int permissionId, UpdatePermissionCommand command)
    {
        var updateCommand = command with { PermissionId = permissionId };
        var result = await _sender.Send(updateCommand);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpPut("permissions/sort")]
    public async Task<IActionResult> UpdatePermissionSort(UpdatePermissionSortCommand command)
    {
        var result = await _sender.Send(command);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpDelete("permission/{permissionId}")]
    public async Task<IActionResult> Delete(int permissionId)
    {
        var result = await _sender.Send(new DeletePermissionCommand(permissionId));
        return result.Match(
            _ => NoContent(),
            Problem);
    }
}
