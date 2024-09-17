using Application.DTO;
using Domain.Entities;
using Infrastructure.Models;

namespace Infrastructure.Repository.Interfaces;

public interface ICoordinatesRepository
{
    public Task<Coordinates?> GetByIdAsync(int id);
    public Task<Coordinates?> GetAllByElementIdAsync(int elementId);
    public Task<Coordinates> CreateAsync(List<CoordinatesDto> data);
    public Task<Coordinates> UpdateAsync(int id, CoordinatesDbUpdate data);
    public Task DeleteAsync(int id);
}