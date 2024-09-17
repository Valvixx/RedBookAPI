namespace Domain.Entities;

public class Coordinates
{
    public int Id { get; set; }
    public int ElementId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double? Altitude { get; set; } = null; //TODO: Как-то нормально оформить
}