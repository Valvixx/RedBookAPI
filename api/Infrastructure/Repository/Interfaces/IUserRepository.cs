using Domain.Entities;
using Infrastructure.Models;

namespace Infrastructure.Repository.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByCredentials(string email, string password);
    Task<User> CreateAsync(UserDbCreate data);
    Task<User> UpdateAsync(int id, UserDbUpdate data);
    Task DeleteAsync(int id);
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetAllAsync();
}