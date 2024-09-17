using System.Security.Claims;
using Domain.Entities;
using Infrastructure.Models;

namespace Applizcation.Services;

public interface IUserService
{
    public Task<User?> GetByIdAsync(int id);
    public Task<List<User>> GetAllAsync();
    public Task<User> CreateAsync(UserDbCreate data, IEnumerable<Claim> requestClaims);
    public Task<User> UpdateAsync(int id, UserDbUpdate data, IEnumerable<Claim> requestClaims);
    public Task DeleteAsync(int id, IEnumerable<Claim> requestClaims);
}