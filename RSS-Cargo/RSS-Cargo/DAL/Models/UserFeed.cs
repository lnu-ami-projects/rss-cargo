// <copyright file="UserFeed.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_cargo.DAL.Models;

using System;
using System.Collections.Generic;

public class UserFeed
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string RssFeed { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
