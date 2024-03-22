using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document4
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? TeachingPlannerId { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Doc> Docs { get; set; } = new List<Doc>();

    public virtual ICollection<Document5> Document5s { get; set; } = new List<Document5>();

    public virtual TeachingPlanner? TeachingPlanner { get; set; }
}
