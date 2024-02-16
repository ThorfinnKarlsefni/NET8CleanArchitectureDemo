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
        var result = await _sender.Send(new GetCurrentUserQuery(user.Id));
        return result.Match(
            _ => Ok(result.Value),
            Problem);
    }

    [HttpGet("user")]
    public async Task<IActionResult> List()
    {
        var result = await _sender.Send(new GetListUserQuery());
        return result.Match(
            _ => Ok(result.Value),
            Problem);
    }
}
