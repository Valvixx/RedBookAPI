namespace Domain.Entities;

using Application.Services.Models;

public class BookElement
{
    public int Id { get; set; }
    public BookElementType Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}