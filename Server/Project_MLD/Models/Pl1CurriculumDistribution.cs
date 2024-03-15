using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Pl1CurriculumDistribution
{
    public int Pl1Id { get; set; }

    public int CurruculumId { get; set; }

    public int Slot { get; set; }

    public string? Description { get; set; }

    public virtual CurriculumDistribution Curruculum { get; set; } = null!;

    public virtual PhuLuc1 Pl1 { get; set; } = null!;
}
