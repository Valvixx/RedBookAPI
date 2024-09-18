using Application.DTO.Auth;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService authService;

    public AuthController(IAuthService authService)
    {
        this.authService = authService;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Authorize(AuthLogin authData)
    {
        var token = await authService.AuthorizeUser(authData);

        return string.IsNullOrWhiteSpace(token)
            ? BadRequest()
            : Ok(token);
    }
}