using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.DTO.Auth;
using Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository userRepository;
    private readonly IConfiguration configuration;
    
    public AuthService(IUserRepository userRepository, IConfiguration configuration)
    {
        this.userRepository = userRepository;
        this.configuration = configuration;
    }
    public async Task<LoginResponse> AuthorizeUser(LoginRequest data)
    {
        if (!ValidateUserData(data))
        {
            return new LoginResponse();
        }

        var user = await userRepository.GetByCredentials(data.Email, data.Password);
        
        if (user == null)
        {
            return new LoginResponse();
        }

        var claims = new[]
        {
            new Claim("UserId", user.UserId.ToString()),
            new Claim("UserName", user.UserName),
            new Claim("Email", user.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var jwtInfo = new JwtSecurityToken(                  
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(4)),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );
        var token = new JwtSecurityTokenHandler().WriteToken(jwtInfo);

        return new LoginResponse
        {
            Token = token,
            Role = user.Role
        };
    }

    private static bool ValidateUserData(LoginRequest? authData)
    {
        return authData != null &&
               !string.IsNullOrWhiteSpace(authData.Email) &&
               !string.IsNullOrWhiteSpace(authData.Password);
    }
}