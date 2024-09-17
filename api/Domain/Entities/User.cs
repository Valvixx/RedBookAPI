using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class User
{
    [Column("user_id")]
    public int UserId { get; set; }
    [Column("user_name")]
    public string UserName { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [Column("password")]
    public string Password { get; set; }
    [Column("created_date")]
    public DateTime CreatedDate { get; set; }
    [Column("role")]
    public UserRole Role { get; set; }
}