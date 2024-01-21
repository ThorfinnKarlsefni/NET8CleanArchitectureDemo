using AutoMapper;
using ErrorOr;
using FluentValidation;
using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Api;

[Route("api/auth")]
public class AuthController : ApiController
{
    private readonly IUserServices _userServices;
    private readonly IMapper _mapper;

    public AuthController(IUserServices userServices, IMapper mapper)
    {
        _userServices = userServices;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequest request, IValidator<UserRegisterRequest> validator)
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return Problem(validationResult.Errors
            .ConvertAll(error => Error.Validation(
                code: error.PropertyName,
                description: error.ErrorMessage)));
        }
        var user = _mapper.Map<User>(request);
        var result = await _userServices.RegisterAndCreateAsync(user);
        return result.Match(
            _ => NoContent(),
            Problem);
    }
}
