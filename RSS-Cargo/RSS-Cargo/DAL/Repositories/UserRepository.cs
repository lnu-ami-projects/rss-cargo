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

    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
    
    public void DeleteUser(User user)
    {
        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    public IEnumerable<User> GetAll() => _context.Users;
}