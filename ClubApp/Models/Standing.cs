using System;
using System.Collections.Generic;

namespace ClubApp.Models;

public partial class Standing
{
    public int Id { get; set; }

    public int? CupId { get; set; }

    public int? TeamId { get; set; }

    public int? Points { get; set; }

    public int? Wins { get; set; }

    public int? Draws { get; set; }

    public int? Losses { get; set; }

    public int? GoalsFor { get; set; }

    public int? GoalsAgainst { get; set; }

    public virtual Cup? Cup { get; set; }

    public virtual Team? Team { get; set; }
}
