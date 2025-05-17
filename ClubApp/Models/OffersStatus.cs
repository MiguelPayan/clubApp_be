using System;
using System.Collections.Generic;

namespace ClubApp.Models;

public partial class OffersStatus
{
    public int Id { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
