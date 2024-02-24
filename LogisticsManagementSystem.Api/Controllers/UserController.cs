using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Api;

public class UserController : ApiController
{
    private readonly ISender _sender;
    private readonly ICurrentUserProvider _currentUserProvider;

    public UserController(ISender sender, ICurrentUserProvider currentUserProvider)
    {
        _sender = sender;
        _currentUserProvider = currentUserProvider;
    }

    [HttpGet("currentUser")]
    public async Task<IActionResult> GetCurrentUser()
    {
        var user = _currentUserProvider.GetCurrentUser();
        var result = await _sender.Send(new CurrentUserQuery(user.Id));
        return result.Match(
            _ => Ok(result.Value),
            Problem);
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetUserList([FromQuery] string? searchKeyword, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _sender.Send(new ListUserQuery(pageNumber, pageSize, searchKeyword));
        return result.Match(
            _ => Ok(result.Value),
            Problem);
    }

    [HttpGet("users/{id}")]
    public async Task<IActionResult> GetUser(string id)
    {
        var result = await _sender.Send(new GetUserQuery(id));
        return result.Match(
            _ => Ok(result.Value),
            Problem);
    }
}
