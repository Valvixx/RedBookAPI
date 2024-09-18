using Domain.Entities;

namespace Infrastructure.Models;

public class UserDbUpdate
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
}