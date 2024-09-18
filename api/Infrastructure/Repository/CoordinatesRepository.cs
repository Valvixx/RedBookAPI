using Application.DTO;
using Domain.Entities;
using Infrastructure.Dapper;
using Infrastructure.Models;
using Infrastructure.Repository.Interfaces;
using System.Text.Json;
using Infrastructure.Dapper.Interfaces;

namespace Infrastructure.Repository;

public class CoordinatesRepository(IDapperContext dapperContext) : ICoordinatesRepository
{
    public async Task<Coordinate?> GetByIdAsync(int id)
    {
        var queryObject =
            new QueryObject(
                "SELECT * FROM coordinates WHERE id = @id", new { id });

        return await dapperContext.FirstOrDefault<Coordinate>(queryObject);
    }

    public async Task<Coordinate?> GetAllByElementIdAsync(int elementId)
    {
        var queryObject =
            new QueryObject(
                "SELECT * FROM coordinates WHERE element_id = @ElementId", new { elementId });
        return await dapperContext.FirstOrDefault<Coordinate>(queryObject);
    }

    public Task<Coordinate> CreateAsync(CoordinatesDbCreate data)
    {
        string jsonCoordinates = JsonSerializer.Serialize(data.Coordinates);
        var query = new QueryObject(
            @"INSERT INTO coordinates (element_id, coordinates)
                 VALUES (@ElementId, @JsonCoordinates) 
                 RETURNING *", new {data.ElementId, jsonCoordinates});
        
        return dapperContext.CommandWithResponse<Coordinate>(query);
    }

    public Task<DbCoordinates> UpdateAsync(int id, CoordinatesDbUpdate data)
    {
        string jsonCoordinates = JsonSerializer.Serialize(data.Coordinates);

        var query = new QueryObject(
            @"UPDATE coordinates 
          SET element_id = @ElementId, 
              coordinates = @Coordinates 
          WHERE id = @Id
          RETURNING *", new
            {
                ElementId = data.ElementId, Coordinates = jsonCoordinates, Id = id
            });
        return dapperContext.CommandWithResponse<DbCoordinates>(query);
    }

    public async Task DeleteAsync(int id)
    {
        var query = new QueryObject(
            @"DELETE FROM coodinates WHERE id = @Id", new {id});
        await dapperContext.Command<Coordinate>(query);
    }
}