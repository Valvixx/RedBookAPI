using Application.DTO.BookElement;
using Application.Services;
using Application.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/book-element")]
public class BookElementController : ControllerBase
{
    private IBookElementService _bookElementService;

    public BookElementController(IBookElementService bookElementService)
    {
        _bookElementService = bookElementService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] BookElementCreate bookElementCreate)
    {
        await _bookElementService.CreateAsync(bookElementCreate);;
        return Ok();
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] BookElementUpdate bookElementUpdate)
    {
        return Ok(await _bookElementService.UpdateAsync(id, bookElementUpdate));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await _bookElementService.DeleteAsync(id);
        return Ok("Succes");
    }

    [HttpGet("by-type/{type:int}")]
    public async Task<IActionResult> GetAllByTypeAsync([FromRoute] BookElementType type)
    {
        return Ok(await _bookElementService.GetAllByType(type));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        return Ok(await _bookElementService.GetById(id));
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchByName([FromQuery] string? name = "")
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return BadRequest();
        }

        return Ok(await _bookElementService.SearchByNameAsync(name));
    }
}