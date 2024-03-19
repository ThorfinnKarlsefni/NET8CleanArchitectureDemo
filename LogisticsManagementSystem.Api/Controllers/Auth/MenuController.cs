using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Contracts;
using LogisticsManagementSystem.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Api;
public class MenuController : ApiController
{
    private readonly IMediator _mediator;

    public MenuController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("menu")]
    public async Task<IActionResult> Create(CreateMenuCommand command)
    {
        var result = await _mediator.Send(command);
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

    [HttpPut("menu/{id}")]
    public async Task<IActionResult> Update(int id, UpdateMenuCommand command)
    {
        var updateCommand = command with { Id = id };
        var result = await _mediator.Send(updateCommand);
        return result.Match(
        _ => NoContent(),
        Problem);
    }

    [HttpGet("menu")]
    public async Task<IActionResult> List()
    {
        var result = await _mediator.Send(new ListMenusQuery());
        return await result.MatchAsync<IActionResult>(
            async _ => Ok(await ToDtoList(result.Value)),
            errors => Task.FromResult<IActionResult>(Problem(errors)));
    }

    [HttpGet("menu/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetMenuQuery(id);
        var result = await _mediator.Send(query);
        return result.Match(
          _ => Ok(result.Value),
          Problem);
    }

    private async Task<List<ListMenuResponse>> ToDtoList(List<Menu> allMenus)
    {
        var menuDictionary = allMenus
            .Where(menu => menu.ParentId != null)
            .GroupBy(menu => menu.ParentId.GetValueOrDefault())
            .ToDictionary(group => group.Key, group => group.ToList());

        var rootMenus = await Task.WhenAll(allMenus
            .Where(menu => menu.ParentId == null)
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
            Children = new List<ListMenuResponse>()
        };

        if (menuDictionary.ContainsKey(menu.Id))
        {
            var children = await Task.WhenAll(menuDictionary[menu.Id]
                .Select(async childMenu => await BuildMenuTreeAsync(childMenu, menuDictionary)));
            menuResponse.Children.AddRange(children);
        }

        return menuResponse;
    }
}
