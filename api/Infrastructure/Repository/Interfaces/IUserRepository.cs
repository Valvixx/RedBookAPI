using Domain.Entities;

namespace Infrastructure.Repository.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByCredentials(string email, string password);
}