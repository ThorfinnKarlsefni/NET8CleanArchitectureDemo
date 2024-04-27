using LogisticsManagementSystem.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace LogisticsManagementSystem.Api;

public class PermissionController : ApiController
{
    private readonly ISender _sender;
    private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

    public PermissionController(ISender sender, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
    {
        _sender = sender;
        _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
    }

    [HttpGet("permission/all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _sender.Send(new AllPermissionQuery());
        return result.Match(
            permissionList => Ok(permissionList),
            Problem);
    }

    [HttpGet("permission/all/path")]
    public IActionResult GetAllPath()
    {
        var routes = _actionDescriptorCollectionProvider.ActionDescriptors.Items
        .Where(x => !string.Equals(x.RouteValues["Controller"], "Auth", StringComparison.OrdinalIgnoreCase))
        .Select(x => new
        {
            Action = x.RouteValues["Action"],
            Controller = x.RouteValues["Controller"],
            Template = x.AttributeRouteInfo?.Template
        })
        .GroupBy(x => x.Template)
        .Select(group => group.First())
        .ToList();

        return Ok(routes);
    }

    [HttpPost("permission")]
    public async Task<IActionResult> Create(CreatePermissionCommand command)
    {
        var result = await _sender.Send(command);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpPut("permission/{id}")]
    public async Task<IActionResult> Update(int id, UpdatePermissionCommand command)
    {
        var updateCommand = command with { Id = id };
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
}
