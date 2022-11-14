// <copyright file="CargoFeed.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_cargo.DAL.Models;

/// <summary>
/// Reperesents cargo feed.
/// </summary>
public class CargoFeed
{
    /// <summary>
    /// Gets or sets id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets cargo id.
    /// </summary>
    public int CargoId { get; set; }

    /// <summary>
    /// Gets or sets feed.
    /// </summary>
    public string RssFeed { get; set; } = null!;

    /// <summary>
    /// Gets or sets cargo.
    /// </summary>
    public virtual Cargo Cargo { get; set; } = null!;
}
