namespace Infrastructure.Models;

public class CoordinatesDbCreate
{
    public int ElementId { get; set; }
    public List<CoordinatesDto>? Coordinates { get; set; }
}