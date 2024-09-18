using Application.DTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Models;
using Infrastructure.Repository.Interfaces;

namespace Application.Services;

public class CoordinatesService(ICoordinatesRepository coordinatesRepository) : ICoordinatesService
{
    public async Task<Coordinates> CreateAsync(CoordinatesDbCreate data)
    {
        return await coordinatesRepository.CreateAsync(data);
    }

    public async Task<Coordinates> UpdateAsync(int id, CoordinatesDbUpdate data)
    {
        return await coordinatesRepository.UpdateAsync(id, data);
    }

    public async Task DeleteAsync(int id)
    {
        await coordinatesRepository.DeleteAsync(id);
    }

    public async Task<Coordinates?> GetAllByElementId(int id)
    {
        return await coordinatesRepository.GetAllByElementIdAsync(id);
    }

    public async Task<Coordinates?> GetById(int id)
    {
        return await coordinatesRepository.GetByIdAsync(id);
    }
}