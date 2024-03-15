using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class PhuLuc5
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Pl4Id { get; set; }

    public int? EvaluateBy { get; set; }

    public virtual User? EvaluateByNavigation { get; set; }

    public virtual PhuLuc4 Pl4 { get; set; } = null!;
}
