using Application.DTO.BookElement;
using Application.Services.Models;
using Infrastructure.Repository;

namespace Application.Services;

public class BookElementService(BookElementRepository bookElementRepository):IBookElementService
{
    public Task CreateBookElementAsync(BookElementCreate bookElementCreate)
    {
        string type = bookElementCreate.Type.ToString();
        string title = bookElementCreate.Title;
        string description = bookElementCreate.Description;
        string placement = bookElementCreate.Placement;
        List<string> images = bookElementCreate.Image;

        bookElementRepository.AddBookElement(type, title, description, placement, images);
        throw new NotImplementedException();
    }

    public Task PatchBookElementAsync(BookElementCreate bookElementCreate)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBookElementAsync()
    {
        throw new NotImplementedException();
    }
}