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

    public async Task<BookElement> UpdateAsync(int id, BookElementUpdate data)
    {
        return await bookElementRepository.UpdateAsync(id, new BookElementDbUpdate
        {
            Type = data.Type,
            Title = data.Title,
            Description = data.Description
        });
    }

    public async Task<BookElement> DeleteAsync(int id)
    {
        return await bookElementRepository.DeleteAsync(id);
    }

    public Task<BookElement> GetAllByType(BookElementType type)
    {
        return await bookElementRepository.GetAllByTypeAsync(type); //TODO: Изменить тип данных в репозитории
    }

    public Task<BookElement> GetById(int id)
    {
        throw new NotImplementedException();
    }
}