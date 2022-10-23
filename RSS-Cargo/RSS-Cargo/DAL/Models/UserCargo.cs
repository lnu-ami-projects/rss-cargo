using System;
using System.Collections.Generic;

namespace RSS_cargo.DAL.Models;

public partial class UserCargo
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CargoId { get; set; }

    public virtual Cargo Cargo { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
