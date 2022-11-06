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

    public void AddCargoUser(int userId, int cargoId)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == userId);
        if (user == null)
        {
            throw new ArgumentException("User Id not found");
        }

        user.UserCargos.Add(new UserCargo{UserId = userId, CargoId = cargoId});
        _context.SaveChanges();
    }
    
    public void DeleteCargoUser(int userId, int cargoId)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == userId);
        if (user == null)
        {
            throw new ArgumentException("User Id not found");
        }
        
        user.UserCargos.Remove(new UserCargo{UserId = userId, CargoId = cargoId});
        _context.SaveChanges();
    }
    
    public void AddFeedUser(int userId, string feed)
    {
        if (!Uri.IsWellFormedUriString(feed, UriKind.Absolute))
        {
            throw new ArgumentException("This is not an URL " + feed);
        }
        
        var user = _context.Users.FirstOrDefault(x=> x.Id == userId);
        
        if (user == null)
        {
            throw new ArgumentException("There is no id like this " + userId);
        }
        
        user.UserFeeds.Add(new UserFeed{RssFeed = feed});
        _context.SaveChanges();
    }
    
    public void DeleteFeedUser(int userId, string feed)
    {
        if (!Uri.IsWellFormedUriString(feed, UriKind.Absolute))
        {
            throw new ArgumentException("This is not an URL " + feed);
        }
        
        var userFeed = _context.UserFeeds.FirstOrDefault(x=> x.UserId == userId && x.RssFeed == feed);
        
        if (userFeed == null)
        {
            throw new ArgumentException("There is no feed like this in this cargo");
        }
        
        _context.UserFeeds.Remove(userFeed);
        _context.SaveChanges();
    }
}