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
}