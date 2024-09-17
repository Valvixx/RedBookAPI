using Application.DTO;
using Application.DTO.BookElement;
using Application.Services.Models;
using Domain.Entities;
using Infrastructure.Models;
using Infrastructure.Repository.Interfaces;

namespace Application.Services;

public class BookElementService(IBookElementRepository bookElementRepository) : IBookElementService
{
    public async Task<BookElement> CreateAsync(BookElementCreate data)
    {
        return await bookElementRepository.CreateAsync(new BookElementDbCreate
        {
            Type = data.Type,
            Title = data.Title,
            Description = data.Description,
        });
    }

    public async Task<BookElement> UpdateAsync(int id, BookElementUpdate data)
    {
        return await bookElementRepository.UpdateAsync(id, new BookElementDbUpdate
        {
            Type = data.Type,
            Title = data.Title,
            Description = data.Description
        });
    }

    public async Task DeleteAsync(int id)
    {
        await bookElementRepository.DeleteAsync(id);
    }

    public async Task<BookElement> GetAllByType(BookElementType type)
    {
        return await bookElementRepository.GetAllByTypeAsync(type);
    }

    public async Task<BookElement> GetById(int id)
    {
        return await bookElementRepository.GetByIdAsync(id);
    }
}