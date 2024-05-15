using ErrorOr;
using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Api;

public class AuthController(ISender _sender) : ApiController
{
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
        var result = await _sender.Send(query);
        return await result.MatchAsync(
             async user => await GenerateTokens(user),
             error => Task.FromResult<IActionResult>(Problem(error)));
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var result = await _sender.Send(new LogoutCommand());
        return result.Match(
            _ => NoContent(),
            Problem);
    }

    private async Task<IActionResult> GenerateTokens(User user)
    {
        var result = await _sender.Send(new GenerateTokenCommand(
            user.Id,
            user.Name,
            user.CompanyId,
            user.UserRoles.Select(x => x.Role.Name).ToList(),
            new List<string>(),
            user.SecurityStamp
        ));
        return result.Match(
            user => Ok(user),
            Problem);
    }

}
