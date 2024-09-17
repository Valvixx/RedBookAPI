using Application.DTO.BookElement;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookElementController : ControllerBase
{
    private IBookElementService _bookElementService;

    public BookElementController(IBookElementService bookElementService)
    {
        _bookElementService = bookElementService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateAsync(BookElementCreate bookElementCreate)
    {
        return Ok(await _bookElementService.CreateAsync(bookElementCreate));
    }
    
    [HttpPatch("Update")]
    public async Task<IActionResult> UpdateAsync(int id,BookElementUpdate bookElementUpdate)
    {
        return Ok(await _bookElementService.UpdateAsync(id, bookElementUpdate));
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _bookElementService.DeleteAsync(id);
        return Ok("Succes");
    }

    [HttpGet("GetAllByType")]
    public async Task<IActionResult> GetAllByTypeAsync(BookElementType type)
    {
        return Ok(await _bookElementService.GetAllByType(type));
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _bookElementService.GetById(id));
    }
}