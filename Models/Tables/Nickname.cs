using System;
using System.Collections.Generic;

namespace mvc.Models.Tables;

public partial class Nickname
{
    public string IdNickname { get; set; } = null!;

    public string? IdCity { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Type { get; set; }

    public string? Address { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Gender { get; set; }

    public string? Job { get; set; }

    public virtual City? IdCityNavigation { get; set; }
}
