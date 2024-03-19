using LogisticsManagementSystem.Application;
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

    [HttpPost("signUp")]
    public async Task<IActionResult> SignUp(CreateUserCommand command)
    {
        var result = await _sender.Send(command);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> LoginUserByUserName(LoginByUserNameCommand query)
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

    [HttpPost("logout")]
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
