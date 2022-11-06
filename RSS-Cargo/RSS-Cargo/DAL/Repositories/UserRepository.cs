using RSS_cargo.DAL.Context;
using RSS_cargo.DAL.Models;

namespace RSS_cargo.DAL.Repositories;

public class UserRepository
{
    private readonly RsscargoContext _context;

    public UserRepository(RsscargoContext context)
    {
        _context = context;
    }

    public void RegisterUser(string email, string username, string password)
    {
        var user = new User
        {
            Email = email,
            Username = username,
            Password = BCrypt.Net.BCrypt.HashPassword(password)
        };

        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User? LoginUser(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);

        if (user == null)
        {
            return null;
        }

        return !BCrypt.Net.BCrypt.Verify(password, user.Password) ? null : user;
    }

    public void DeleteUser(int userId)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return;
        }

        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}