using System;
using System.Collections.Generic;

namespace ClubApp.Models;

public partial class Budget
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public double? MainBudget { get; set; }

    public double? ClauseBudget { get; set; }

    public byte[] UpdatedAt { get; set; } = null!;

    public virtual User? User { get; set; }
}
