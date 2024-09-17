using Applizcation.Services;
using Domain.Entities;
using Infrastructure.Models;

namespace Application.Services;

public class UserService: IUserService
{
    public Task<User> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> CreateAsync(UserDbCreate data)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(int id, UserDbUpdate data)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(int id)
    {
        throw new NotImplementedException();
    }
}