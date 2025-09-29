using System;
using System.Collections.Generic;

namespace ClubApp.Models;

public partial class Game
{
    public int Id { get; set; }

    public int? CupId { get; set; }

    public int? TeamAId { get; set; }

    public int? TeamBId { get; set; }

    public int? ScoreTeamA { get; set; }

    public int? ScoreTeamB { get; set; }

    public bool? IsFinished { get; set; }

    public int? FinishedByUserId { get; set; }

    public virtual Cup? Cup { get; set; }

    public virtual User? FinishedByUser { get; set; }

    public virtual Team? TeamA { get; set; }

    public virtual Team? TeamB { get; set; }
}
