using Application.Services.Models;

namespace Application.DTO;

public record BookElementDbUpdate
{
    public BookElementType? Type { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}