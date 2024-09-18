namespace Application.DTO.BookElement;

public class BookElementMapper
{
    public static BookElementCreate MapToDefaultResponse(Domain.Entities.BookElement element)
    {
        return new BookElementCreate()
        {
            Type = element.Type,
            Name = element.Name,
            Description = element.Description,
        };
    }
    
}