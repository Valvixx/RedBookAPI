using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Models;
using Infrastructure.Repository.Interfaces;

namespace Application.Services;

public class CoordinatesService(ICoordinatesRepository coordinatesRepository) : ICoordinatesService
{
    public async Task<Coordinates> CreateAsync(CoordinatesDbCreate data)
    {
        var coordinates = data.Coordinates;
        
        return await coordinatesRepository.CreateAsync(coordinates);
    }

    public Task<Coordinates> UpdateAsync()
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Coordinates> GetAllByElementId(int id)
    {
        return await coordinatesRepository.GetAllByElementIdAsync(id);
    }

    public Task<Coordinates> GetById(int id)
    {
        throw new NotImplementedException();
    }
}