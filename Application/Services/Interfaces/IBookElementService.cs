using Application.DTO.BookElement;
using Domain.Entities;

namespace Application.Services;

public interface IBookElementService
{
    // CRUD. Делать апдейт через patch
    Task<BookElement> CreateAsync(BookElementCreate data);
    Task<BookElement> UpdateAsync(int id, BookElementCreate data);
    Task DeleteAsync(int id);
    

}