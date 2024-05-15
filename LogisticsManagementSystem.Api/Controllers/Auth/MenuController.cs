using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Contracts;
using LogisticsManagementSystem.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace LogisticsManagementSystem.Api;
public class MenuController(
    IMediator _mediator, IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider) : ApiController
{

    [HttpGet("menus")]
    public async Task<IActionResult> GetMenus()
    {
        var result = await _mediator.Send(new GetMenusQuery());
        // Actually, you don't have to convert it to a tree
        return await result.MatchAsync<IActionResult>(
            async menus => Ok(await ToDtoTree(menus)),
            errors => Task.FromResult<IActionResult>(Problem(errors)));
    }

    [HttpGet("menu/list")]
    public async Task<IActionResult> ListMenu()
    {
        var result = await _mediator.Send(new ListMenusQuery());
        return await result.MatchAsync<IActionResult>(
            async menus => Ok(await ToDtoTree(menus)),
            errors => Task.FromResult<IActionResult>(Problem(errors)));
    }

    [HttpGet("menu/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetMenuQuery(id);
        var result = await _mediator.Send(query);
        return result.Match(
          menu => Ok(menu),
          Problem);
    }


    [HttpGet("menu/controllers")]
    public IActionResult GetControllers()
    {
        var controllers = _actionDescriptorCollectionProvider.ActionDescriptors.Items
        .Where(x => !string.Equals(x.RouteValues["Controller"], "Auth", StringComparison.OrdinalIgnoreCase))
        .Select(x => x.RouteValues["Controller"])
        .Distinct(StringComparer.OrdinalIgnoreCase)
        .ToList();

        return Ok(controllers);
    }

    [HttpGet("menu/permissions")]
    public async Task<IActionResult> GetPermissonMenu()
    {
        var result = await _mediator.Send(new GetPermissionMenuQuery());
        return result.Match(
            permissionMenus => Ok(permissionMenus),
            Problem);
    }

    [HttpPost("menu")]
    public async Task<IActionResult> Create(CreateMenuCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpPut("menu/{id}")]
    public async Task<IActionResult> Update(int id, UpdateMenuCommand command)
    {
        var updateCommand = command with { Id = id };
        var result = await _mediator.Send(updateCommand);
        return result.Match(
        _ => NoContent(),
        Problem);
    }

    [HttpPut("menu/sort")]
    public async Task<IActionResult> UpdateMenuSort(UpdateMenuSortCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpPut("menu/{id}/visibility")]
    public async Task<IActionResult> Visibility(int id)
    {
        var result = await _mediator.Send(new VisibilityMenuCommand(id));
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpDelete("menu/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteMenuCommand(id);
        var result = await _mediator.Send(command);
        return result.Match(
           _ => NoContent(),
           Problem);
    }

    private async Task<List<ListMenuResponse>> ToDtoTree(List<Menu> allMenus)
    {
        var menuDictionary = allMenus
            .Where(menu => menu.ParentId != null)
            .GroupBy(menu => menu.ParentId.GetValueOrDefault())
            .ToDictionary(group => group.Key, group => group.ToList());

        var rootMenus = await Task.WhenAll(allMenus
            .Where(menu => menu.ParentId == null)
            .OrderBy(menu => menu.Sort)
            .Select(async rootMenu => await BuildMenuTreeAsync(rootMenu, menuDictionary)));

        return rootMenus.ToList();
    }

    private async Task<ListMenuResponse> BuildMenuTreeAsync(Menu menu, Dictionary<int, List<Menu>> menuDictionary)
    {
        var menuResponse = new ListMenuResponse
        {
            Id = menu.Id,
            ParentId = menu.ParentId,
            Name = menu.Name,
            Path = menu.Path,
            Component = menu.Component,
            Visibility = menu.Visibility,
            Sort = menu.Sort,
            Children = new List<ListMenuResponse>()
        };

        if (menuDictionary.ContainsKey(menu.Id))
        {
            var children = await Task.WhenAll(menuDictionary[menu.Id]
                .OrderBy(menu => menu.Sort)
                .Select(async childMenu => await BuildMenuTreeAsync(childMenu, menuDictionary)));
            menuResponse.Children.AddRange(children);
        }

        return menuResponse;
    }
}
