using LogisticsManagementSystem.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Api;

public class UserController : ApiController
{
    private ISender _sender;

    public UserController(ISender sender, IHttpContextAccessor httpContextAccessor)
    {
        _sender = sender;
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserInfo(string userId)
    {
        if (userId is null)
            return Problem(statusCode: StatusCodes.Status400BadRequest, title: "用户不存在");

        var query = new GetUserInfoQuery(userId);
        var result = await _sender.Send(query);
        return result.Match(
            _ => Ok(result.Value),
            Problem
        );
    }
}
