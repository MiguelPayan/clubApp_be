using System;
using System.Collections.Generic;

namespace ClubApp.Models;

public partial class Offer
{
    public int Id { get; set; }

    public int? FromTeamId { get; set; }

    public int? ToTeamId { get; set; }

    public int? ToPlayerId { get; set; }

    public double? Amount { get; set; }

    public int? StatusId { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public virtual Team? FromTeam { get; set; }

    public virtual OffersStatus? Status { get; set; }

    public virtual Player? ToPlayer { get; set; }

    public virtual Team? ToTeam { get; set; }
}
