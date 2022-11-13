// <copyright file="Cargo.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_cargo.DAL.Models;

using System.Collections.Generic;

public class Cargo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CargoFeed> CargoFeeds { get; } = new List<CargoFeed>();

    public virtual ICollection<UserCargo> UserCargos { get; } = new List<UserCargo>();
}
