namespace Domain.Entities;

public class Image
{
    public int Id { get; set; }
    public int BookElementId { get; set; }
    public string Reference { get; set; }
    public string Name { get; set; }
}