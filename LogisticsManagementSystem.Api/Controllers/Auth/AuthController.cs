using LogisticsManagementSystem.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Api;

[Route("api/auth")]
public class AuthController : ApiController
{
    private readonly ISender _sender;

    public AuthController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
    {
        var result = await _sender.Send(command);
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpPost("generate/token")]
    public async Task<IActionResult> GenerateTokens([FromBody] GenerateTokenCommand command)
    {
        var result = await _sender.Send(command);
        return result.Match(
            _ => Ok(result.Value),
            Problem);
    }
}
