using Application.Services.Models;

namespace Application.DTO;

public record BookElementDbCreate
{
    public BookElementType Type { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}