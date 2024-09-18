using Domain.Entities;

namespace Application.DTO.Auth;

public class LoginResponse
{
    public string Token { get; set; }
    public UserRole Role { get; set; }
}