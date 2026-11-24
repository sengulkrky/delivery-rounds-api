using DeliveryRoundsApi.Dtos;
using DeliveryRoundsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryRoundsApi.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var success = await _service.RegisterAsync(dto);

        if (!success)
        {
            return Problem(
                title: "Username already exists.",
                statusCode: StatusCodes.Status409Conflict);
        }

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var token = await _service.LoginAsync(dto);

        if (token is null)
        {
            return Unauthorized();
        }

        return Ok(token);
    }
}
