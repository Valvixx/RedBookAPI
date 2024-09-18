using Application.DTO;
using Domain.Entities;
using Infrastructure.Models;

namespace Infrastructure.Repository.Interfaces;

public interface ICoordinatesRepository
{
    public Task<Coordinate?> GetByIdAsync(int id);
    public Task<Coordinate?> GetAllByElementIdAsync(int elementId);
    public Task<Coordinate> CreateAsync(CoordinatesDbCreate data);
    public Task<DbCoordinates> UpdateAsync(int id, CoordinatesDbUpdate data);
    public Task DeleteAsync(int id);
}