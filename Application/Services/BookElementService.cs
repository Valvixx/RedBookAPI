using Application.DTO.BookElement;
using Infrastructure.Models;
using Infrastructure.Repository;

namespace Application.Services;

public class BookElementService(BookElementRepository bookElementRepository) : IBookElementService
{
    public async Task CreateAsync(BookElementCreate data)
    {
        // TODO: замапать DB сущность в DTO
        return bookElementRepository.CreateAsync(new BookElementDbCreate
        {
            Type = data.Type.ToString(),
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