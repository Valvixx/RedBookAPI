using Application.Services.Models;

namespace Application.DTO.BookElement;

public class BookElementUpdate
{
    public BookElementType? Type { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}