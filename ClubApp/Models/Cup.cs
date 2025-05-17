using System;
using System.Collections.Generic;

namespace ClubApp.Models;

public partial class Cup
{
    public int Id { get; set; }

    public string? NameCup { get; set; }

    public int? CreatedByUserId { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public bool? Finished { get; set; }

    public virtual User? CreatedByUser { get; set; }

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();

    public virtual ICollection<Standing> Standings { get; set; } = new List<Standing>();
}
