using GameWeb.Logic.Models;

namespace GameWeb.Logic.Stores;

public interface IUserStore
{
    Task<User?> GetById(int id);
    Task<User?> GetByName(string username);
    Task Add(User user);
}