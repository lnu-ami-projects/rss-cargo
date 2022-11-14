// <copyright file="UserCargo.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_cargo.DAL.Models;

/// <summary>
/// Repersents user cargo.
/// </summary>
public class UserCargo
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
    /// Gets or sets cargo id.
    /// </summary>
    public int CargoId { get; set; }

    /// <summary>
    /// Gets or sets cargo.
    /// </summary>
    public virtual Cargo Cargo { get; set; } = null!;

    /// <summary>
    /// Gets or sets user.
    /// </summary>
    public virtual User User { get; set; } = null!;
}
