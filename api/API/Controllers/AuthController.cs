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
    public async Task<ActionResult<LoginResponse>> Authorize([FromBody] LoginRequest data)
    {
        var response = await authService.AuthorizeUser(data);

        return response == new LoginResponse()
            ? BadRequest()
            : Ok(response);
    }
}