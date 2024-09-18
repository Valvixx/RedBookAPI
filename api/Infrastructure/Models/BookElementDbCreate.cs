using Application.Services.Models;
using Domain.Entities;

namespace Infrastructure.Models;

public record BookElementDbCreate
{
    public BookElementType Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}