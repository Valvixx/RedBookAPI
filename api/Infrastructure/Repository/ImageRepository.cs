using Application.DTO;
using Domain.Entities;
using Infrastructure.Dapper;
using Infrastructure.Dapper.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Repository;

public class ImageRepository(IDapperContext dapperContext) : ImageDbCreate
{
    public async Task<Image> CreateAsync(ImageDbCreate data)
    {
        var query = new QueryObject(
            "INSERT INTO element_images (element_id, reference, name)" +
            "VALUES (@element_id, @reference, @name)", new { data });
        return await dapperContext.CommandWithResponse<Image>(query);
    }

    public async Task<Image> UpdateAsync(int id, ImageDbUpdate data)
    {
        var query = new QueryObject(
            "UPDATE element_images " +
            "SET reference = @reference, " +
            "name = @name " +
            "WHERE id = @id", new { data.Reference, data.Name, id });
        return await dapperContext.CommandWithResponse<Image>(query);
    }

    public async Task<Image> DeleteAsync(int id)
    {
        var query = new QueryObject(
            "DELETE FROM element_images WHERE id = @Id", new { id });
        return await dapperContext.CommandWithResponse<Image>(query);
    }

    public async Task<List<string>> GetReferenceByElementId(int elementId)
    {
        var query = new QueryObject(
            "SELECT reference FROM element_images WHERE element_id = @elementId", new { elementId });
        return await dapperContext.CommandWithResponse<List<string>>(query);
    }
}
