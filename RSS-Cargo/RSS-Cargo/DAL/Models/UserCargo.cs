// <copyright file="UserCargo.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_cargo.DAL.Models;

using System;
using System.Collections.Generic;

public class UserCargo
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CargoId { get; set; }

    public virtual Cargo Cargo { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
