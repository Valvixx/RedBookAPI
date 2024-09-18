using Domain.Entities;

namespace Infrastructure.Models;

public class UserDbCreate
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }

    public bool IsValid => !string.IsNullOrWhiteSpace(UserName) &&
                           !string.IsNullOrWhiteSpace(Email) &&
                           !string.IsNullOrWhiteSpace(Password);
}