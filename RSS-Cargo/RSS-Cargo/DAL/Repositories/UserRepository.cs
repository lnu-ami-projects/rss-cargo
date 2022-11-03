using Org.BouncyCastle.Crypto.Generators;
using RSS_cargo.DAL.Context;
using RSS_cargo.DAL.Models;
using System.Collections.Generic;
using System.Linq;

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
        var user = _context.Users.First(u => u.Email == email);

        if (user == null)
        {
            return null;
        }

        if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            return null;
        }

        return user;
    }

    public void DeleteUser(int userId)
    {
        var user = _context.Users.First(u => u.Id == userId);

        if (user == null)
        {
            return;
        }

        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}