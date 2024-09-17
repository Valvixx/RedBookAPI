using Domain.Entities;
using Infrastructure.Models;

namespace Application.Services.Interfaces;

public interface ICoordinatesService
{
    Task<Coordinates> CreateAsync(CoordinatesDbCreate data);
    Task<Coordinates> UpdateAsync();
    Task DeleteAsync(int id);
    Task<Coordinates> GetAllByElementId(int id);
    Task<Coordinates> GetById(int id);
}