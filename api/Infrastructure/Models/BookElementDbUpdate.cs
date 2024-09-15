using Application.Services.Models;

namespace Infrastructure.Models;

public record BookElementDbUpdate
{
    public BookElementType? Type { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}