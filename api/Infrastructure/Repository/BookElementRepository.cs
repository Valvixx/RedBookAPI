using Application.Services.Models;
using Infrastructure.Dapper;
using Infrastructure.Dapper.Interfaces;
using Domain.Entities;
using Infrastructure.Models;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository;

public class BookElementRepository(IDapperContext dapperContext) : IBookElementRepository
{
    public async Task<BookElement?> GetByIdAsync(int id)
    {
        var queryObject =
            new QueryObject(
                "SELECT * FROM book_elements WHERE id = @id", new { id });

        return await dapperContext.FirstOrDefault<BookElement>(queryObject);
    }

    public async Task<BookElement?> GetAllByTypeAsync(BookElementType type)
    {
        var queryObject =
            new QueryObject(
                "SELECT * FROM book_elements WHERE type = @type", new { type });
        return await dapperContext.FirstOrDefault<BookElement>(queryObject);
    }

    public Task<BookElement> CreateAsync(BookElementDbCreate data)
    {
        var query = new QueryObject(
            @"INSERT INTO book_elements(type, title, description)
                 VALUES (@Type, @Title, @Description)
                 returning *", data);

        return dapperContext.CommandWithResponse<BookElement>(query);
    }

    public Task<BookElement> UpdateAsync(int id, BookElementDbUpdate data)
    {
        var query = new QueryObject(
            @"UPDATE book_elements 
          SET type = @Type, 
              title = @Title, 
              description = @Description 
          WHERE id = @Id
          RETURNING *", new { data.Type, data.Title, data.Description, Id = id });
        return dapperContext.CommandWithResponse<BookElement>(query);
    }

    public async Task DeleteAsync(int id)
    {
        var query = new QueryObject(
            @"DELETE FROM book_elements WHERE id = @Id", new {id});
        await dapperContext.Command<BookElement>(query);
    }
}