using Infrastructure.Models;

namespace Domain.Entities;

public class Coordinate
{
    public int Id { get; set; }
    public int ElementId { get; set; }
    public List<CoordinatesDto> Coordinates { get; set; }
}