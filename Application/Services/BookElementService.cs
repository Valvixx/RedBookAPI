using Application.DTO.BookElement;
using Domain.Entities;
using Infrastructure.Models;
using Infrastructure.Repository;

namespace Application.Services;

public class BookElementService(BookElementRepository bookElementRepository) : IBookElementService
{
    public async Task<BookElement> CreateAsync(BookElementCreate data)
    {
        //TODO: замапать DB сущность в DTO
        return await bookElementRepository.CreateAsync(new BookElementDbCreate
        {
            Type = data.Type,
            Title = data.Title,
            Description = data.Description,
            Latitude = data.Latitude,
            Longitude = data.Longitude
        });
    }

    public async Task<BookElement> UpdateAsync(int id, BookElementCreate data)
    {
        return await bookElementRepository.UpdateAsync(id, new BookElementDbUpdate
        {
            Type = data.Type,
            Title = data.Title,
            Description = data.Description,
            Latitude = data.Latitude,
            Longitude = data.Longitude
        });
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}