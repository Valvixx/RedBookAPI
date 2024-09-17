namespace Domain.Entities;

public class User
{
    [Column("user_id")]
    public int UserId { get; set; }
    [Column("display_name")]
    public string DisplayName { get; set; }
    [Column("user_name")]
    public string UserName { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [Column("password")]
    public string Password { get; set; }
    [Column("created_date")]
    public DateTime CreatedDate { get; set; }
}