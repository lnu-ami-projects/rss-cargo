﻿using System;
using System.Collections.Generic;

namespace RSS_cargo.DAL.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<UserCargo> UserCargos { get; } = new List<UserCargo>();

    public virtual ICollection<UserFeed> UserFeeds { get; } = new List<UserFeed>();
}
