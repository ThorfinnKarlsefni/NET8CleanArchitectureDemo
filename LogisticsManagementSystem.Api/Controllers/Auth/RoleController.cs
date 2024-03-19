using LogisticsManagementSystem.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Api;

public class RoleController : ApiController
{
    private readonly ISender _sender;

    public RoleController(ISender sender)
    {
        _sender = sender;
    }


    [HttpGet("roles")]
    public async Task<IActionResult> GetListRoles(ListRoleQuery query)
    {
        var result = await _sender.Send(query);
        return result.Match(
            _ => Ok(result.Value),
            Problem);
    }

    [HttpGet("roles/all")]
    public async Task<IActionResult> GetAllRoles()
    {
        var result = await _sender.Send(new AllRoleQuery());
        return result.Match(
            _ => Ok(result.Value),
            Problem);
    }

    [HttpPost("roles")]
    public async Task<IActionResult> CreateRole(CreateRoleCommand command)
    {
        var result = await _sender.Send(command);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpDelete("role/{roleId}")]
    public async Task<IActionResult> DeleteRole(string roleId)
    {
        if (!Guid.TryParse(roleId, out var id))
        {
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                title: "无效Id格式"
            );
        }
        var deleteCommand = new DeleteRoleCommand(roleId);
        var result = await _sender.Send(deleteCommand);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

}
