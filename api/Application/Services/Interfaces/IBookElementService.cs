using Application.DTO.BookElement;
using Application.Services.Models;
using Domain.Entities;

namespace Application.Services;

public interface IBookElementService
{
    // CRUD. Делать апдейт через patch
    Task<BookElement> CreateAsync(BookElementCreate data);
    Task<BookElement> UpdateAsync(int id, BookElementUpdate data);
    Task<BookElement> DeleteAsync(int id);
    Task<BookElement> GetAllByType(BookElementType type);
    Task<BookElement> GetById(int id);
}