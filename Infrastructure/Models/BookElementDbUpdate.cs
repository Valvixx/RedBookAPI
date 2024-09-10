namespace Infrastructure.Models;

public record BookElementDbUpdate
{
    public string? Type { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Placement { get; set; }
}