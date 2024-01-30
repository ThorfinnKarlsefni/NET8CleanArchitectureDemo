using LogisticsManagementSystem.Application;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Api;

[Route("api/auth")]
[AllowAnonymous]
public class LoginController : ApiController
{
    private readonly ISender _sender;

    public LoginController(ISender sender)
    {
        _sender = sender;
    }



    [HttpPost("login")]
    public async Task<IActionResult> LoginUserByUserName([FromBody] LoginByUserNameCommand query)
    {
        var user = await _sender.Send(query);
        if (user.Value is null)
            return Problem(user.Errors);
        var generateCommand = new GenerateTokenCommand(user.Value);
        var result = await _sender.Send(generateCommand);
        return result.Match(
            _ => Ok(result.Value),
            Problem);
    }
}