using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Contracts;
using LogisticsManagementSystem.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Api;

public class AuthController : ApiController
{
    private readonly ISender _sender;

    public AuthController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("auth/signUp")]
    public async Task<IActionResult> SignUp([FromBody] CreateUserCommand command)
    {
        var result = await _sender.Send(command);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [AllowAnonymous]
    [HttpPost("auth/login")]
    public async Task<IActionResult> LoginUserByUserName([FromBody] LoginByUserNameCommand query)
    {
        var user = await _sender.Send(query);
        var result = await GenerateTokens(user.Value);
        return result;
        // return result.Match(
        //     token => CreatedAtAction(
        //         actionName: nameof(GenerateTokens),
        //         routeValues: new { user = token },
        //         value: token
        //     ),
        //     Problem);
    }

    [HttpPost("auth/logout")]
    public async Task<IActionResult> Logout()
    {
        return NoContent();
    }

    private async Task<IActionResult> GenerateTokens(User user)
    {
        var result = await _sender.Send(new GenerateTokenCommand(user));
        return result.Match(
            _ => Ok(result.Value),
            Problem);
    }

}
