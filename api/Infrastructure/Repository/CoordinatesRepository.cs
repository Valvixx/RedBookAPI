using Application.DTO;
using Domain.Entities;
using Infrastructure.Dapper;
using Infrastructure.Models;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository;

public class CoordinatesRepository(DapperContext dapperContext) : ICoordinatesRepository
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
        var query = new QueryObject(
            @"INSERT INTO coordinates (element_id, coordinates)
                 VALUES (@ElementId, @Coordinates) 
                 RETURNING *", data);
        
        return dapperContext.CommandWithResponse<Coordinates>(query);
    }

    public Task<Coordinates> UpdateAsync(int id, CoordinatesDbUpdate data)
    {
        var query = new QueryObject(
            @"UPDATE coordinates 
          SET element_id = @ElementId, 
              coordinates = @Coordinates, 
          WHERE id = @Id
          RETURNING *", new { data.ElementId, data.Coordinates, Id = id });
        return dapperContext.CommandWithResponse<Coordinates>(query);
    }

    public async Task DeleteAsync(int id)
    {
        var query = new QueryObject(
            @"DELETE FROM coodinates WHERE id = @Id", new {id});
        await dapperContext.Command<Coordinates>(query);
    }
}