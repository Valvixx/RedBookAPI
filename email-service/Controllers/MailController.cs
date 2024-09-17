using email_service.Models.Service;
using email_service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace email_service.Controllers;

[ApiController]
[Route("[controller]")]
public class MailController(IMailService mailService) : ControllerBase
{
    [HttpPost("send")]
    public async Task<IActionResult> SendMail([FromBody] MailRequest request)
    {
        await mailService.SendEmailAsync(request);
        return Ok();
    }

    [HttpGet("ping")]
    public async Task<IActionResult> Ping()
    {
        return Ok("pong");
    }
}