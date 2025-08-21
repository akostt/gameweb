namespace GameWeb.Persistence.Models;

public class UserEntity
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    
    public CredentialsEntity? Credentials { get; set; }
}