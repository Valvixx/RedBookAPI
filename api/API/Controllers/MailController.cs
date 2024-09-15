using Application.Microservices.MailService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

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