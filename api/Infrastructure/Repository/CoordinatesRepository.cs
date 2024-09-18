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
    public async Task<Coordinates?> GetByIdAsync(int id)
    {
        var queryObject =
            new QueryObject(
                "SELECT * FROM coordinates WHERE id = @id", new { id });

        return await dapperContext.FirstOrDefault<Coordinates>(queryObject);
    }

    public async Task<Coordinates?> GetAllByElementIdAsync(int elementId)
    {
        var queryObject =
            new QueryObject(
                "SELECT * FROM coordinates WHERE element_id = @ElementId", new { elementId });
        return await dapperContext.FirstOrDefault<Coordinates>(queryObject);
    }

    public Task<Coordinates> CreateAsync(CoordinatesDbCreate data)
    {
        string jsonCoordinates = JsonSerializer.Serialize(data.Coordinates);
        var query = new QueryObject(
            @"INSERT INTO coordinates (element_id, coordinates)
                 VALUES (@ElementId, @JsonCoordinates) 
                 RETURNING *", new {data.ElementId, jsonCoordinates});
        
        return dapperContext.CommandWithResponse<Coordinates>(query);
    }

    public Task<Coordinates> UpdateAsync(int id, CoordinatesDbUpdate data)
    {
        string jsonCoordinates = JsonSerializer.Serialize(data.Coordinates);

        var query = new QueryObject(
            @"UPDATE coordinates 
          SET element_id = @ElementId, 
              coordinates = @Coordinates 
          WHERE id = @Id
          RETURNING *", new
            {
                data.ElementId, jsonCoordinates, Id = id
            });
        return dapperContext.CommandWithResponse<Coordinates>(query);
    }

    public async Task DeleteAsync(int id)
    {
        var query = new QueryObject(
            @"DELETE FROM coodinates WHERE id = @Id", new {id});
        await dapperContext.Command<Coordinates>(query);
    }
}