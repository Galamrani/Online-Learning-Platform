using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineLearning.API;


[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;


    public UserController(UserService userService)
    {
        _userService = userService;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        if (!ModelState.IsValid) return BadRequest(new ValidationError(ModelState.GetAllErrors()));

        string? token = await _userService.RegisterAsync(registerDto);
        if (token == null) return BadRequest(new EmailExistsError(registerDto.Email));

        return Created(string.Empty, token);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] CredentialsDto credentialsDto)
    {
        if (!ModelState.IsValid) return BadRequest(new ValidationError(ModelState.GetAllErrors()));

        string? token = await _userService.LoginAsync(credentialsDto);
        if (token == null) return Unauthorized(new InvalidCredentials());

        return Ok(token);
    }
}

