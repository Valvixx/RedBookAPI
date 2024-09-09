using Application.DTO.BookElement;

namespace Application.Services;

public interface IBookElementService
{
    // CRUD. Делать апдейт через patch
    Task CreateBookElementAsync(BookElementCreate bookElementCreate);
    Task PatchBookElementAsync(BookElementCreate bookElementCreate);
    Task DeleteBookElementAsync();
    

}