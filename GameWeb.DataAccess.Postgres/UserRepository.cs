using GameWeb.Logic.Models;
using GameWeb.Logic.Stores;
using GameWeb.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace GameWeb.Persistence;

public class UserRepository(AppDbContext context) : IUserStore
{
    public async Task<User?> GetById(int id)
    {
        var userEntity = await context.Users.FirstOrDefaultAsync(u => u.Id == id) ?? throw new KeyNotFoundException();

        var user = new User
        {
            Id = userEntity.Id,
            Username = userEntity.Username,
            Email = userEntity.Credentials.Email,
            Password = userEntity.Credentials.Password
        };
        return user;
    }

    public async Task<User?> GetByName(string username)
    {
        var userEntity = await context.Users.FirstOrDefaultAsync(u => u.Username == username) ?? throw new KeyNotFoundException();

        var user = new User
        {
            Id = userEntity.Id,
            Username = userEntity.Username,
            Email = userEntity.Credentials.Email,
            Password = userEntity.Credentials.Password
        };
        return user;
    }

    public async Task Add(User user)
    {
        var userEntity = new UserEntity
        {
            Username = user.Username
        };
        await context.Users.AddAsync(userEntity);
        await context.SaveChangesAsync();
        user.Id = userEntity.Id;
        
        var credentialsEntity = new CredentialsEntity
        {
            UserId = user.Id,
            Email = user.Email,
            Password = user.Password
        };
        await context.Credentials.AddAsync(credentialsEntity);
        await context.SaveChangesAsync();
    }
}