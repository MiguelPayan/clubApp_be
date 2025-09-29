using System;
using System.Collections.Generic;

namespace ClubApp.Models;

public partial class Team
{
    public int Id { get; set; }

    public string? Teamname { get; set; }

    public int? OwneruserId { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public virtual ICollection<Game> GameTeamAs { get; set; } = new List<Game>();

    public virtual ICollection<Game> GameTeamBs { get; set; } = new List<Game>();

    public virtual ICollection<Offer> OfferFromTeams { get; set; } = new List<Offer>();

    public virtual ICollection<Offer> OfferToTeams { get; set; } = new List<Offer>();

    public virtual User? Owneruser { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

    public virtual ICollection<Standing> Standings { get; set; } = new List<Standing>();
}
