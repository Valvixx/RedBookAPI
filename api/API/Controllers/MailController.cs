using Application.Microservices.MailService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class MailController(IMailService mailService) : ControllerBase
{
    [HttpGet("pingg")]
    public async Task<IActionResult> Ping()
    {
        return Ok(await mailService.Ping());
    }
}