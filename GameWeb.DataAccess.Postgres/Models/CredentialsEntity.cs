namespace GameWeb.Persistence.Models;

public class CredentialsEntity
{
    public int UserId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    
    public UserEntity? User { get; set; }
}