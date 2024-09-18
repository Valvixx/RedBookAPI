using System.Security.Claims;
using Applizcation.Services;
using Domain.Entities;
using Infrastructure.Models;
using Infrastructure.Repository.Interfaces;

namespace Application.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public Task<User?> GetByIdAsync(int id) =>
        userRepository.GetByIdAsync(id);

    public Task<List<User>> GetAllAsync() =>
        userRepository.GetAllAsync();

    public async Task<User> CreateAsync(UserDbCreate data, IEnumerable<Claim> requestClaims)
    {
        if (!await IsRequestUserAdmin(requestClaims))
        {
            return new User();
        }

        if (!data.IsValid)
        {
            return new User();
        }
        
        var existingUser = await userRepository.GetByEmail(data.Email);
        
        if (existingUser != null)
        {
            return new User();
        }

        return await userRepository.CreateAsync(data);
    }

    public async Task<User> UpdateAsync(int id, UserDbUpdate data, IEnumerable<Claim> requestClaims)
    {
        if (!await IsRequestUserAdmin(requestClaims))
        {
            return new User();
        }
        
        var user = await userRepository.GetByIdAsync(id);

        if (user == null)
        {
            return new User();
        }

        data.UserName = string.IsNullOrWhiteSpace(data.UserName) ? user.UserName : data.UserName;
        data.Email = string.IsNullOrWhiteSpace(data.Email) ? user.Email : data.Email;
        data.Password = string.IsNullOrWhiteSpace(data.Password) ? user.Password : data.Password;

        return await userRepository.UpdateAsync(id, data);
    }

    public async Task DeleteAsync(int id, IEnumerable<Claim> requestClaims)
    {
        if (!await IsRequestUserAdmin(requestClaims))
        {
            return;
        }

        await userRepository.DeleteAsync(id);
    }

    private async Task<bool> IsRequestUserAdmin(IEnumerable<Claim> claims)
    {
        var userIdClaim = claims.FirstOrDefault(claim => claim.Type == "UserId");

        if (userIdClaim == null)
        {
            return false;
        }

        var userId = Int32.Parse(userIdClaim.Value);
        var user = await userRepository.GetByIdAsync(userId);

        return user?.Role == UserRole.Admin;
    }
}