using Infrastructure.Dapper;
using Infrastructure.Dapper.Interfaces;
using Domain.Entities;
using Infrastructure.Models;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository;

public class BookElementRepository(IDapperContext dapperContext) : IBookElementRepository
{
    public async Task<BookElement?> GetByIdAsync(string title)
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
            @"INSERT INTO book_elements(type, title, description, latitude, longitude)
                 VALUES (@Type, @Data, @Description, @latitude, @longitude)
                 returning *", new {data});

        return dapperContext.CommandWithResponse<BookElement>(query);
    }

    public Task<BookElement> UpdateAsync(int id, BookElementDbUpdate data)
    {
        var query = new QueryObject(
            @"UPDATE book_elements 
          SET type = @Type, 
              title = @Title, 
              description = @Description, 
              latitude = @Latitude, 
              longitude = @Longitude 
          WHERE id = @Id
          RETURNING *", new { data.Type, data.Title, data.Description, data.Latitude, data.Longitude, Id = id });
        return dapperContext.CommandWithResponse<BookElement>(query);
    }

    public async Task<BookElement> DeleteAsync(int id)
    {
        var query = new QueryObject(
            @"DELETE FROM book_elements WHERE id = @Id", new {id});
        return await dapperContext.CommandWithResponse<BookElement>(query);
    }
}