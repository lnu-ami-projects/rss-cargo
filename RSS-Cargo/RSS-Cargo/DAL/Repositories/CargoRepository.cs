// <copyright file="CargoRepository.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_cargo.DAL.Repositories;

using System;
using System.Linq;
using RSS_cargo.DAL.Context;
using RSS_cargo.DAL.Models;

public class CargoRepository
{
    private readonly RsscargoContext context;

    public CargoRepository(RsscargoContext context)
    {
        this.context = context;
    }

    public Cargo? GetCargo(int id)
    {
        return this.context.Cargos.FirstOrDefault(x => x.Id == id);
    }

    public void AddCargo(string name)
    {
        this.context.Cargos.Add(new Cargo { Name = name });
        this.context.SaveChanges();
    }

    public void DeleteCargo(string name)
    {
        var cargo = this.context.Cargos.FirstOrDefault(x => x.Name == name);

        if (cargo == null)
        {
            throw new ArgumentException("There is no name like this " + name);
        }

        this.context.Cargos.Remove(cargo);
        this.context.SaveChanges();
    }

    public void AddFeedCargo(string name, string feed)
    {
        if (!Uri.IsWellFormedUriString(feed, UriKind.Absolute))
        {
            throw new ArgumentException("This is not an URL " + feed);
        }

        var cargo = this.context.Cargos.FirstOrDefault(x => x.Name == name);

        if (cargo == null)
        {
            throw new ArgumentException("There is no name like this " + name);
        }

        cargo.CargoFeeds.Add(new CargoFeed { RssFeed = feed });
        this.context.SaveChanges();
    }

    public void DeleteFeedCargo(int idCargo, string feed)
    {
        if (!Uri.IsWellFormedUriString(feed, UriKind.Absolute))
        {
            throw new ArgumentException("This is not an URL " + feed);
        }

        var cargoFeed = this.context.CargoFeeds.FirstOrDefault(x => x.CargoId == idCargo && x.RssFeed == feed);

        if (cargoFeed == null)
        {
            throw new ArgumentException("There is no feed like this in this cargo");
        }

        this.context.CargoFeeds.Remove(cargoFeed);
        this.context.SaveChanges();
    }
}