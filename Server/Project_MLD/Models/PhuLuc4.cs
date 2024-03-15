using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class PhuLuc4
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? TeachingPlannerId { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<PhuLuc5> PhuLuc5s { get; set; } = new List<PhuLuc5>();

    public virtual TeachingPlanner? TeachingPlanner { get; set; }
}
