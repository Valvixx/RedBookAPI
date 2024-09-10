using Application.DTO.BookElement;
using Application.Services.Models;
using Infrastructure.Models;
using Infrastructure.Repository;

namespace Application.Services;

public class BookElementService(BookElementRepository bookElementRepository):IBookElementService
{
    public Task CreateAsync(BookElementCreate data)
    {
        bookElementRepository.CreateAsync(new BookElementDbCreate
        {
            Type = data.Type,
            Title = data.Title,
            Description = data.Description,
            Placement = data.Placement
        });
    }

    public Task UpdateAsync(int id, BookElementCreate data)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}