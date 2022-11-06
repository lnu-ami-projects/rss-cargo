using RSS_cargo.DAL.Context;
using RSS_cargo.DAL.Models;

namespace RSS_cargo.DAL.Repositories;

public class CargoRepository
{
    private readonly RsscargoContext _context;

    public CargoRepository(RsscargoContext context)
    {
        _context = context;
    }

    public Cargo? GetCargo(int id)
    {
        return _context.Cargos.FirstOrDefault(x=> x.Id == id);
    }

    public void AddCargo(string name)
    {
        _context.Cargos.Add( new Cargo {Name = name});
        _context.SaveChanges();
    }

    public void DeleteCargo(string name)
    {
        var cargo = _context.Cargos.FirstOrDefault(x => x.Name == name);
        
        if (cargo == null)
        {
            throw new ArgumentException("There is no name like this " + name);
        }
        
        _context.Cargos.Remove(cargo);
        _context.SaveChanges();
    }

    public void AddFeedCargo(string name, string feed)
    {
        if (!Uri.IsWellFormedUriString(feed, UriKind.Absolute))
        {
            throw new ArgumentException("This is not an URL " + feed);
        }
        
        var cargo = _context.Cargos.FirstOrDefault(x=> x.Name == name);
        
        if (cargo == null)
        {
            throw new ArgumentException("There is no name like this " + name);
        }
        
        cargo.CargoFeeds.Add(new CargoFeed{RssFeed = feed});
        _context.SaveChanges();
    }
    
    public void DeleteFeedCargo(int idCargo, string feed)
    {
        if (!Uri.IsWellFormedUriString(feed, UriKind.Absolute))
        {
            throw new ArgumentException("This is not an URL " + feed);
        }
        
        var cargoFeed = _context.CargoFeeds.FirstOrDefault(x=> x.CargoId == idCargo && x.RssFeed == feed);
        
        if (cargoFeed == null)
        {
            throw new ArgumentException("There is no feed like this in this cargo");
        }
        
        _context.CargoFeeds.Remove(cargoFeed);
        _context.SaveChanges();
    }
}