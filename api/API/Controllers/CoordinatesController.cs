using Application.DTO;
using Application.Services.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoordinatesController: ControllerBase
{
    private ICoordinatesService _coordinatesService;

    public CoordinatesController(ICoordinatesService coordinatesService)
    {
        _coordinatesService = coordinatesService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CoordinatesDbCreate coordinatesDbCreate)
    {
        return Ok(await _coordinatesService.CreateAsync(coordinatesDbCreate));
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateAsync(int id, CoordinatesDbUpdate coordinatesDbUpdate)
    {
        return Ok(await _coordinatesService.UpdateAsync(id, coordinatesDbUpdate));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _coordinatesService.DeleteAsync(id);
        return Ok("Success");
    }

    [HttpGet("GetByElementId")]
    public async Task<IActionResult> GetAllByElementId(int elementId)
    {
        return Ok(await _coordinatesService.GetAllByElementId(elementId));
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById( int id)
    {
        return Ok(await _coordinatesService.GetById(id));
    }
}