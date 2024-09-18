using Application.DTO;
using Domain.Entities;
using Infrastructure.Models;

namespace Application.Services.Interfaces;

public interface ICoordinatesService
{
    Task<Coordinate> CreateAsync(CoordinatesDbCreate data);
    Task<Coordinate> UpdateAsync(int id, CoordinatesDbUpdate data);
    Task DeleteAsync(int id);
    Task<Coordinate?> GetAllByElementId(int id);
    Task<Coordinate?> GetById(int id);
}