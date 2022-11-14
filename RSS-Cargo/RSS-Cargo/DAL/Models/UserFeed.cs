// <copyright file="UserFeed.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_cargo.DAL.Models;

/// <summary>
/// Represetns user feed.
/// </summary>
public class UserFeed
{
    /// <summary>
    /// Gets or sets id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets user id.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Gets or sets feed.
    /// </summary>
    public string RssFeed { get; set; } = null!;

    /// <summary>
    /// Gets or sets user.
    /// </summary>
    public virtual User User { get; set; } = null!;
}
