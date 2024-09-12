using Application.Services.Models;
using Domain.Entities;

namespace Infrastructure.Models;

public record BookElementDbCreate
{
    public BookElementType Type { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Latitude  { get; set; }
    public double Longitude  { get; set; }
}