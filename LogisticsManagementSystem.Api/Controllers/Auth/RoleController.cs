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

    [HttpPost("auth")]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand command)
    {
        var result = await _sender.Send(command);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpDelete("auth/role/{roleId}")]
    public async Task<IActionResult> DeleteRole(string roleId)
    {
        if (!Guid.TryParse(roleId, out var id))
        {
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                detail: "无效Id格式"
            );
        }
        var deleteCommand = new DeleteRoleCommand(roleId);
        var result = await _sender.Send(deleteCommand);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

}
