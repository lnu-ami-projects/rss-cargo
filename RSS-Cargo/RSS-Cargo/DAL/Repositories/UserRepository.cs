// <copyright file="UserRepository.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_cargo.DAL.Repositories;

using System;
using System.Linq;
using RSS_Cargo;
using RSS_cargo.DAL.Context;
using RSS_cargo.DAL.Models;

public class UserRepository
{
    private readonly RsscargoContext context;

    public UserRepository(RsscargoContext context)
    {
        this.context = context;
    }

    public void RegisterUser(string email, string username, string password)
    {
        var user = new User
        {
            Email = email,
            Username = username,
            Password = BCrypt.Net.BCrypt.HashPassword(password),
        };

        Program.Log.Info($"Registering user {email}");

        this.context.Users.Add(user);
        this.context.SaveChanges();
    }

    public User? LoginUser(string email, string password)
    {
        Program.Log.Info($"Login user {email}");

        var user = this.context.Users.FirstOrDefault(u => u.Email == email);

        if (user == null)
        {
            return null;
        }

        return !BCrypt.Net.BCrypt.Verify(password, user.Password) ? null : user;
    }

    public void DeleteUser(int userId)
    {
        Program.Log.Info($"Delete user {userId}");

        var user = this.context.Users.FirstOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return;
        }

        this.context.Users.Remove(user);
        this.context.SaveChanges();
    }

    public void AddCargoUser(int userId, int cargoId)
    {
        var user = this.context.Users.FirstOrDefault(x => x.Id == userId);
        if (user == null)
        {
            throw new ArgumentException("User Id not found");
        }

        user.UserCargos.Add(new UserCargo { UserId = userId, CargoId = cargoId });
        this.context.SaveChanges();
    }

    public void DeleteCargoUser(int userId, int cargoId)
    {
        var user = this.context.Users.FirstOrDefault(x => x.Id == userId);
        if (user == null)
        {
            throw new ArgumentException("User Id not found");
        }

        user.UserCargos.Remove(new UserCargo { UserId = userId, CargoId = cargoId });
        this.context.SaveChanges();
    }

    public void AddFeedUser(int userId, string feed)
    {
        if (!Uri.IsWellFormedUriString(feed, UriKind.Absolute))
        {
            throw new ArgumentException("This is not an URL " + feed);
        }

        var user = this.context.Users.FirstOrDefault(x => x.Id == userId);

        if (user == null)
        {
            throw new ArgumentException("There is no id like this " + userId);
        }

        user.UserFeeds.Add(new UserFeed { RssFeed = feed });
        this.context.SaveChanges();
    }

    public void DeleteFeedUser(int userId, string feed)
    {
        if (!Uri.IsWellFormedUriString(feed, UriKind.Absolute))
        {
            throw new ArgumentException("This is not an URL " + feed);
        }

        var userFeed = this.context.UserFeeds.FirstOrDefault(x => x.UserId == userId && x.RssFeed == feed);

        if (userFeed == null)
        {
            throw new ArgumentException("There is no feed like this in this cargo");
        }

        this.context.UserFeeds.Remove(userFeed);
        this.context.SaveChanges();
    }
}