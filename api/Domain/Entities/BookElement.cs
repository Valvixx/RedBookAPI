namespace Domain.Entities;

using Application.Services.Models;

public class BookElement
{
    public int Id { get; set; }
    public BookElementType Type { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}