using Infrastructure.Models;

namespace Application.DTO;

public class CoordinatesDbUpdate
{
    public int ElementId { get; set; }
    public List<CoordinatesDto>? Coordinates { get; set; }
}