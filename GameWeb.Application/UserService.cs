using GameWeb.Logic.Models;
using GameWeb.Logic.Stores;

namespace GameWeb.Application;

public class UserService(IUserStore userStore)
{
    public async Task<User?> GetById(int userId)
    {
        return await userStore.GetById(userId);
    }

    public async Task<User?> GetByName(string username)
    {
        return await userStore.GetByName(username);
    }

    public async Task Add(User user)
    {
        var existedUser = await userStore.GetByName(user.Username);
        if (existedUser != null)
        {
            throw new Exception("User already exists");
        }
        await userStore.Add(user);
    }
}