// <copyright file="User.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_cargo.DAL.Models;

using System.Collections.Generic;

/// <summary>
/// Reperesents user.
/// </summary>
public class User
{
    /// <summary>
    /// Gets or sets id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets username.
    /// </summary>
    public string Username { get; set; } = null!;

    /// <summary>
    /// Gets or sets email.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Gets or sets password.
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary>
    /// Gets user cargos.
    /// </summary>
    public virtual ICollection<UserCargo> UserCargos { get; } = new List<UserCargo>();

    /// <summary>
    /// Gets user feeds.
    /// </summary>
    public virtual ICollection<UserFeed> UserFeeds { get; } = new List<UserFeed>();
}
