using System.Text.Json;
using Application.DTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Models;
using Infrastructure.Repository.Interfaces;

namespace Application.Services;

public class CoordinatesService(ICoordinatesRepository coordinatesRepository) : ICoordinatesService
{
    public async Task<Coordinate> CreateAsync(CoordinatesDbCreate data)
    {
        return await coordinatesRepository.CreateAsync(data);
    }

    public async Task<Coordinate> UpdateAsync(int id, CoordinatesDbUpdate data)
    {
        var upd = await coordinatesRepository.UpdateAsync(id, data);
        var coord = new Coordinate()
        {
            Id = upd.Id,
            ElementId = upd.ElementId,
            Coordinates = JsonSerializer.Deserialize<List<CoordinatesDto>>(upd.Coordinates)
        };
        return coord;
    }

    public async Task DeleteAsync(int id)
    {
        await coordinatesRepository.DeleteAsync(id);
    }

    public async Task<Coordinate?> GetAllByElementId(int id)
    {
        return await coordinatesRepository.GetAllByElementIdAsync(id);
    }

    public async Task<Coordinate?> GetById(int id)
    {
        return await coordinatesRepository.GetByIdAsync(id);
    }
}