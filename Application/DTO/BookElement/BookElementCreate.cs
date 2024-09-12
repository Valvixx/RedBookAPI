using Application.Services.Models;

namespace Application.DTO.BookElement;

public record BookElementCreate
{
    public BookElementType Type { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Latitude  { get; set; }
    public double Longitude  { get; set; }
    public List<string> Image { get; set; }
}   