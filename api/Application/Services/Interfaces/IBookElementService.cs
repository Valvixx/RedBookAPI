using Application.DTO.BookElement;
using Application.Services.Models;
using Domain.Entities;

namespace Application.Services;

public interface IBookElementService
{
    Task CreateAsync(BookElementCreate data);
    Task<BookElement> UpdateAsync(int id, BookElementUpdate data);
    Task DeleteAsync(int id);
    Task<List<BookElement>> GetAllByType(BookElementType type);
    Task<BookElement?> GetById(int id);
    Task<List<BookElement>> SearchByNameAsync(string name);
}