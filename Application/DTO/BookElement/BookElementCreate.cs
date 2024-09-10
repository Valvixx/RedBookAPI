using Application.Services.Models;

namespace Application.DTO.BookElement;

public class BookElementCreate
{
    public ElementType.Type Type { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Placement { get; set; }
    public List<string> Image { get; set; }
}