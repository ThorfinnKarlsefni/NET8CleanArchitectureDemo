using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Api;

public class UserController : ApiController
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;

    }

    // [HttpGet("currentUser")]
    // public async Task<IActionResult> GetCurrentUser()
    // {
    //     var user = _currentUserProvider.GetCurrentUser();
    //     var result = await _mediator.Send(new CurrentUserQuery(user.Id.ToString()));
    //     return result.Match(
    //         _ => Ok(result.Value),
    //         Problem);
    // }

    [HttpGet("users")]
    public async Task<IActionResult> GetUserList(int pageNumber, int pageSize, string? searchKeyword, bool? disable)
    {
        var result = await _mediator.Send(new UserListQuery(
            pageNumber,
            pageSize,
            searchKeyword,
            disable
        ));
        return result.Match(
            userList => Ok(userList),
            Problem);
    }

    [HttpGet("users/{id}")]
    public async Task<IActionResult> GetUser(string id)
    {
        var result = await _mediator.Send(new GetUserQuery(id));
        return result.Match(
            user => Ok(user),
            Problem);
    }

    [HttpPut("users/{id}")]
    public async Task<IActionResult> UpdateUser(string id, UpdateUserCommand command)
    {
        var updateCommand = command with { Id = id };
        var result = await _mediator.Send(updateCommand);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpPut("users/{id}/disable")]
    public async Task<IActionResult> DisableUser(string id)
    {
        var result = await _mediator.Send(new DisableUserCommand(id));
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpPut("users/{id}/recover")]
    public async Task<IActionResult> RecoverUser(string id)
    {
        var result = await _mediator.Send(new RecoverUserCommand(id));
        return result.Match(
            _ => NoContent(),
            Problem);
    }
}
