using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document1CurriculumDistribution
{
    public int Document1Id { get; set; }

    public int CurruculumId { get; set; }

    public int Slot { get; set; }

    public string? Description { get; set; }

    public virtual CurriculumDistribution Curruculum { get; set; } = null!;

    public virtual Document1 Document1 { get; set; } = null!;
}
