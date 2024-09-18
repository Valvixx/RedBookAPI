using Application.Services.Models;

namespace Application.DTO;

public record BookElementDbCreate
{
    public BookElementType Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}