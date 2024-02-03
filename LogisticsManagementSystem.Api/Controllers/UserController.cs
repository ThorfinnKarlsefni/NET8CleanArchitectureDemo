using System.Security.Claims;
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

    [HttpGet("user")]
    public async Task<IActionResult> GetUserInfo()
    {
        var user = _currentUserProvider.GetCurrentUser();
        Console.WriteLine("End");
        var result = await _sender.Send(new GetUserInfoQuery(user.Id));
        return result.Match(
            _ => Ok(result.Value),
            Problem
        );
    }
}
