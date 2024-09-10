using Application.DTO.BookElement;

namespace Application.Services;

public interface IBookElementService
{
    // CRUD. Делать апдейт через patch
    Task CreateAsync(BookElementCreate data);
    Task UpdateAsync(int id, BookElementCreate data);
    Task DeleteAsync(int id);
    

}