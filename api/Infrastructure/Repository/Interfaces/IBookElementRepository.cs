using Application.Services.Models;
using Domain.Entities;
using Infrastructure.Models;

namespace Infrastructure.Repository.Interfaces;

public interface IBookElementRepository
{
    public Task<BookElement?> GetByIdAsync(int id);
    public Task<BookElement?> GetAllByTypeAsync(BookElementType type);
    public Task<BookElement> CreateAsync(BookElementDbCreate data);
    public Task<BookElement> UpdateAsync(int id, BookElementDbUpdate data);
    public Task DeleteAsync(int id);
    
}