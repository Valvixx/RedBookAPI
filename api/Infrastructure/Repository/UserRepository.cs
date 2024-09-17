using Domain.Entities;
using Infrastructure.Dapper;
using Infrastructure.Models;
using Infrastructure.Repository.Interfaces;
using Infrastructure.Scripts.User;

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
        var query = new QueryObject(
            @"UPDATE users 
          SET type = @Type, 
              username = @Username, 
              email = @Email, 
              password = @Password 
          WHERE id = @Id
          RETURNING *", new { data.Type, data.Username, data.Email, data.Password, id });
        return dapperContext.CommandWithResponse<User>(query);
    }

    public async Task DeleteAsync(int id)
    {
        var query = new QueryObject(
            @"DELETE FROM users WHERE id = @Id", new {id});
        await dapperContext.Command<User>(query);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var queryObject =
            new QueryObject(
                "SELECT * FROM users WHERE id = @id", new { id });

        return await dapperContext.FirstOrDefault<User>(queryObject);
    }

    public async Task<User?> GetAllAsync()
    {
        var queryObject =
            new QueryObject(
                "SELECT * FROM users", new {});
        return await dapperContext.FirstOrDefault<User>(queryObject);
    }
}