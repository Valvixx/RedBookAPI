using Application.DTO;
using Application.DTO.BookElement;
using Application.Services.Models;
using Domain.Entities;
using Infrastructure.Models;
using Infrastructure.Repository.Interfaces;

namespace Application.Services;

public class BookElementService(IBookElementRepository bookElementRepository) : IBookElementService
{
    public async Task CreateAsync(BookElementCreate data)
    {
        await bookElementRepository.CreateAsync(new BookElementDbCreate
        {
            Type = data.Type,
            Name = data.Name,
            Description = data.Description,
        });
    }

    public async Task<BookElement> UpdateAsync(int id, BookElementUpdate data)
    {
        return await bookElementRepository.UpdateAsync(id, new BookElementDbUpdate
        {
            Type = data.Type,
            Name = data.Name,
            Description = data.Description
        });
    }

    public Task DeleteAsync(int id) => 
        bookElementRepository.DeleteAsync(id);

    public Task<List<BookElement>> GetAllByType(BookElementType type) => 
        bookElementRepository.GetAllByTypeAsync(type);

    public Task<BookElement?> GetById(int id) => 
        bookElementRepository.GetByIdAsync(id);

    public async Task<List<BookElement>> SearchByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return new List<BookElement>();
        }

        return await bookElementRepository.SearchByNameAsync(name);
    }
}