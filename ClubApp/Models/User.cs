using System;
using System.Collections.Generic;

namespace ClubApp.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Role { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public string? GoogleId { get; set; }

    public virtual Budget? Budget { get; set; }

    public virtual ICollection<Cup> Cups { get; set; } = new List<Cup>();

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();

    public virtual Team? Team { get; set; }
}
