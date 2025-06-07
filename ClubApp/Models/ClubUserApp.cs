using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ClubApp.Models;

public partial class ClubUserApp : IdentityUser
{
    public string? Lema { get; set; }

    public virtual Budget? Budget { get; set; }

    public virtual ICollection<Cup> Cups { get; set; } = new List<Cup>();

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();

    public virtual Team? Team { get; set; }
}
