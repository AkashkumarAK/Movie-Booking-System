using Microsoft.AspNetCore.Mvc;
using MovieBooking.API.DTO.Auth;
using MovieBooking.API.Services;

namespace MovieBooking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }


    // POST: api/Auth/register
    [HttpPost("register")]
    public async Task<IActionResult> Register(
        RegisterRequest request)
    {
        var token = await _authService.RegisterAsync(request);

        if (token == null)
        {
            return Conflict("Email already exists.");
        }

        return Ok(new
        {
            message = "Registration successful",
            token = token
        });
    }


    // POST: api/Auth/login
    [HttpPost("login")]
    public async Task<IActionResult> Login(
        LoginRequest request)
    {
        var token = await _authService.LoginAsync(request);

        if (token == null)
        {
            return Unauthorized("Invalid email or password.");
        }

        return Ok(new
        {
            message = "Login successful",
            token = token
        });
    }
}