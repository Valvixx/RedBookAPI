using Domain.Entities;
using Infrastructure.Dapper;
using Infrastructure.Dapper.Interfaces;
using Infrastructure.Models;
using Infrastructure.Repository.Interfaces;
using Infrastructure.Scripts.User;

namespace Infrastructure.Repository;

public class UserRepository(IDapperContext dapperContext) : IUserRepository
{
    public async Task<User?> GetByCredentials(string email, string password)
    {
        var query = new QueryObject(PostgresUser.GetByCredentials, new { Email = email, Password = password });
        return await dapperContext.FirstOrDefault<User>(query);
    }

    public async Task<User?> GetByEmail(string email)
    {
        var query = new QueryObject(PostgresUser.GetByEmail, new { Email = email });
        return await dapperContext.FirstOrDefault<User>(query);
    }

    public Task<User> CreateAsync(UserDbCreate data)
    {
        var parameters = new
        {
            UserName = data.UserName,
            Email = data.Email,
            Password = data.Password,
            CreatedDate = DateTime.UtcNow,
            Role = data.Role
        };
        
        var query = new QueryObject(PostgresUser.Insert, parameters);
        
        return dapperContext.CommandWithResponse<User>(query);
    }

    public Task<User> UpdateAsync(int id, UserDbUpdate data)
    {
        var parameters = new
        {
            UserName = data.UserName,
            Email = data.Email,
            Password = data.Password,
            Role = data.Role,
            UserId = id
        };
        
        var query = new QueryObject(PostgresUser.Update, parameters);
        
        return dapperContext.CommandWithResponse<User>(query);
    }

    public async Task DeleteAsync(int id)
    {
        var query = new QueryObject(PostgresUser.Delete, new { UserId = id });
        await dapperContext.Command<User>(query);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var queryObject = new QueryObject(PostgresUser.GetById, new { UserId = id });
        return await dapperContext.FirstOrDefault<User>(queryObject);
    }

    public async Task<List<User>> GetAllAsync()
    {
        var queryObject = new QueryObject(PostgresUser.GetAll, new{} );
        return await dapperContext.ListOrEmpty<User>(queryObject) ?? new List<User>();
    }
}