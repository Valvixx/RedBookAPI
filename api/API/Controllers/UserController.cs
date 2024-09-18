using Applizcation.Services;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("user")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) =>
        Ok(await userService.GetByIdAsync(id));

    [HttpGet("all")]
    public async Task<IActionResult> GetAll() =>
        Ok(await userService.GetAllAsync());

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserDbCreate createData) =>
        Ok(await userService.CreateAsync(createData, HttpContext.User.Claims));

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserDbUpdate updateData) =>
        Ok(await userService.UpdateAsync(id, updateData, HttpContext.User.Claims));

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await userService.DeleteAsync(id, HttpContext.User.Claims);
        return Ok();
    }
}