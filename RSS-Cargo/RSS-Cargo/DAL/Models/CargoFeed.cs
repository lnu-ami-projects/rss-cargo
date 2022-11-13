// <copyright file="CargoFeed.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_cargo.DAL.Models;

using System;
using System.Collections.Generic;

public class CargoFeed
{
    public int Id { get; set; }

    public int CargoId { get; set; }

    public string RssFeed { get; set; } = null!;

    public virtual Cargo Cargo { get; set; } = null!;
}
