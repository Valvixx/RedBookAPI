using Infrastructure.Dapper;
using Infrastructure.Dapper.Interfaces;
using Domain.Entities;
using Infrastructure.Models;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository;

public class BookElementRepository(IDapperContext dapperContext) : IBookElementRepository
{
    public async Task<BookElement?> GetByTitleAsync(string title)
    {
        var queryObject =
            new QueryObject(
                "SELECT * FROM book_elements WHERE title = @title", new { title });

        return await dapperContext.FirstOrDefault<BookElement>(queryObject);
    }

    public async Task<BookElement?> GetAllByTypeAsync(string type)
    {
        var queryObject =
            new QueryObject(
                "SELECT * FROM book_elements WHERE type = @type", new { type });
        return await dapperContext.FirstOrDefault<BookElement>(queryObject);
    }

    public Task<BookElement> CreateAsync(BookElementDbCreate data)
    {
        var query = new QueryObject(
            @"insert into book_elements(type, title, description)
                 values (@Type, @Data, @Description)
                 returning *",
            data);

        return dapperContext.CommandWithResponse<BookElement>(query);
    }

    public Task<BookElement> UpdateAsync(int id, BookElementDbUpdate data)
    {
        var query = new QueryObject(); //TODO: Сделать апдейт запрос + делит
        return dapperContext.CommandWithResponse<BookElement>(query);
    }

    public async Task<BookElement> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}