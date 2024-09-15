using Domain.Entities;
using Infrastructure.Dapper;
using Infrastructure.Models;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository;

public class UserRepository(DapperContext dapperContext) : IUserRepository
{
    public Task<User> CreateAsync(UserDbCreate data)
    {
        var query = new QueryObject(
            @"INSERT INTO users(type, username, email, password)
                 VALUES (@Type, @Title, @Username, @Password)
                 returning *", data);
        
        return dapperContext.CommandWithResponse<User>(query);
    }

    public Task<User> UpdateAsync(int id, UserDbUpdate data)
    {
        throw new NotImplementedException();
    }

    public Task<User> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}