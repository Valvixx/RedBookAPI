using Domain.Entities;
using Infrastructure.Dapper;
using Infrastructure.Dapper.Interfaces;
using Infrastructure.Repository.Interfaces;
using Infrastructure.Scripts.User;

namespace Infrastructure.Repository;

public class UserRepository(IDapperContext context) : IUserRepository
{
    public async Task<User?> GetByCredentials(string email, string password)
    {
        var query = new QueryObject(PostgresUser.GetByCredentials, new { Email = email, Password = password });
        return await context.FirstOrDefault<User>(query);
    }
}