using Domain.Entities;
using Infrastructure.Models;

namespace Applizcation.Services;

public interface IUserService
{
    public Task<User> GetByIdAsync(int id);
    public Task<User> GetAllAsync();
    public Task<User> CreateAsync(UserDbCreate data);
    public Task<User> UpdateAsync(int id, UserDbUpdate data);
    public Task DeleteUser(int id);
}