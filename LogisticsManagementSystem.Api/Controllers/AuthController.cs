using AutoMapper;
using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Api;

[Route("api/auth")]
public class AuthController : ApiController
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AuthController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    // [HttpPost]
    // public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
    // {
    //     return Ok();
    // }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
    {
        var user = _mapper.Map<User>(request);
        var result = await _userRepository.CreateAsync(user);

        return result.Match(
            _ => NoContent(),
            Problem);
    }
}
