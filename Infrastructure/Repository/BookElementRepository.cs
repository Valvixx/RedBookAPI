using Infrastructure.Dapper;
using Infrastructure.Dapper.Interfaces;
using Domain.Entities;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository;

public class BookElementRepository(IDapperContext dapperContext):IBookElementRepository
{
    public async Task<BookElement?> GetBookElementByTitle(string title)
    {
        var queryObject =
            new QueryObject(
                "SELECT * FROM book_elements WHERE title = @title", new {title});
        return await dapperContext.FirstOrDefault<BookElement>(queryObject);
    }

    public async Task<BookElement?> GetAllBookElementsByType(string type)
    {
        var queryObject =
            new QueryObject(
                "SELECT * FROM book_elements WHERE type = @type", new {type});
        return await dapperContext.FirstOrDefault<BookElement>(queryObject);
    }

    public async Task<BookElement> AddBookElement(string type, string title, string description, string placement, string image)
    {
        var queryObject =
            new QueryObject(
                "INSERT INTO book_elements(type, title, description, image)" +
                " VALUES(@type, @title, @description) RETURNING *",
                new { type, title, description, image });
        return await dapperContext.CommandWithResponse<BookElement>(queryObject);
    }

    public Task<BookElement> PatchBookElement(string type, string title, string description, string placement, string image)
    {
        throw new NotImplementedException();
    }

    public Task<BookElement> DeleteBookElement(string type, string title, string description, string placement, string image)
    {
        throw new NotImplementedException();
    }
}