using JwtAuthentication.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcessFlow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IJwtAuthenticationService _jwtAuthenticationService;

    public AuthController(IJwtAuthenticationService jwtAuthenticationService)
    {
        _jwtAuthenticationService = jwtAuthenticationService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserModel user)
    {
        if (!ValidateUser(user))
            return Unauthorized("Invalid credentials");

        var token = _jwtAuthenticationService.GenerateJwtToken(user.Username);
        return Ok(new { token });
    }

    [HttpGet("secure")]
    [Authorize]
    public IActionResult SecureEndpoint()
    {
        return Ok("This is a secure endpoint.");
    }
    [HttpPost("validate")]
    public bool ValidateUser(UserModel user)
    {
        // Hardcoded for demo; use database in production
        return user.Username == "admin@gmail.com" && user.Password == "admin123";
    }
    public class UserModel {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
