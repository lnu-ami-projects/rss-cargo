// <copyright file="Cargo.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_cargo.DAL.Models;

using System.Collections.Generic;

/// <summary>
/// Repersetns cargo.
/// </summary>
public class Cargo
{
    /// <summary>
    /// Gets or sets id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets name.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets cargos feeds.
    /// </summary>
    public virtual ICollection<CargoFeed> CargoFeeds { get; } = new List<CargoFeed>();

    /// <summary>
    /// Gets user cargos feeds.
    /// </summary>
    public virtual ICollection<UserCargo> UserCargos { get; } = new List<UserCargo>();
}
