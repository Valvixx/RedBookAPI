namespace Infrastructure.Models;

public class GetAllCoordinatesByElementId
{
    public List<CoordinatesDto> Coordinates { get; set; }
    public int Count { get; set; }
}