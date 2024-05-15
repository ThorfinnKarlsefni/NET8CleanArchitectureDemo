using LogisticsManagementSystem.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Api;

public class UserController(
    IMediator _mediator,
    ICurrentUserProvider _currentUserProvider) : ApiController
{
    [HttpGet("users/list")]
    public async Task<IActionResult> GetUserList(int pageNumber, int pageSize, string? searchKeyword, bool? disable)
    {
        var result = await _mediator.Send(new ListUserQuery(
            pageNumber,
            pageSize,
            searchKeyword,
            disable
        ));
        return result.Match(
            userList => Ok(userList),
            Problem);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUser(Guid userId)
    {
        var result = await _mediator.Send(new GetUserQuery(userId));
        return result.Match(
            user => Ok(user),
            Problem);
    }

    [HttpGet("user/currentUser")]
    public async Task<IActionResult> GetCurrentUser()
    {
        var currentUser = _currentUserProvider.GetCurrentUser();
        var result = await _mediator.Send(new GetUserQuery(currentUser.Id));
        return result.Match(
            user => Ok(user),
            Problem);
    }

    [HttpPut("user/{userId}")]
    public async Task<IActionResult> UpdateUser(Guid userId, UpdateUserCommand command)
    {
        var updateCommand = command with { UserId = userId };
        var result = await _mediator.Send(updateCommand);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpPut("user/{userId}/disable")]
    public async Task<IActionResult> DisableUser(Guid userId)
    {
        var result = await _mediator.Send(new DisableUserCommand(userId));
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpPut("user/{userId}/recover")]
    public async Task<IActionResult> RecoverUser(Guid userId)
    {
        var result = await _mediator.Send(new RecoverUserCommand(userId));
        return result.Match(
            _ => NoContent(),
            Problem);
    }
}
