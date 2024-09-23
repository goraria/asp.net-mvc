using System;
using System.Collections.Generic;

namespace mvc.Models.Tables;

public partial class City
{
    public string IdCity { get; set; } = null!;

    public string? Name { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Nickname> Nicknames { get; set; } = new List<Nickname>();
}
