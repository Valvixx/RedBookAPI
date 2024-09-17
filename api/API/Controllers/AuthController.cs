using Application.DTO.Auth;
using Application.Services;
using Domain.Entities;
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
    
    [HttpPost]
    public async Task<IActionResult> Authorize(AuthLogin authData)
    {
        var token = await authService.AuthorizeUser(authData);

        return string.IsNullOrWhiteSpace(token)
            ? BadRequest()
            : Ok(token);
    }
}