using System;
using System.Collections.Generic;

namespace ClubApp.Models;

public partial class Player
{
    public int Id { get; set; }

    public int? TeamId { get; set; }

    public string? PhotoSrc { get; set; }

    public string? Playername { get; set; }

    public int? Age { get; set; }

    public string? OriginalTeam { get; set; }

    public int? OverallRating { get; set; }

    public int? Potential { get; set; }

    public double? MarketValue { get; set; }

    public int? Shooting { get; set; }

    public int? Dribling { get; set; }

    public int? Pace { get; set; }

    public int? Strenght { get; set; }

    public int? Interceptions { get; set; }

    public int? DefensiveAwareness { get; set; }

    public int? Reflects { get; set; }

    public double? ReleaseClause { get; set; }

    public double? PositionX { get; set; }

    public double? PositionY { get; set; }

    public bool? IsStarting { get; set; }

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual Team? Team { get; set; }
}
