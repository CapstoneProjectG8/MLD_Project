using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document4
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? TeachingPlannerId { get; set; }

    public bool? Status { get; set; }

    public string? CreatedDate { get; set; }

    public string? LinkFile { get; set; }

    public string? LinkImage { get; set; }

    public virtual ICollection<Document5> Document5s { get; set; } = new List<Document5>();

    public virtual ICollection<Scorm> Scorms { get; set; } = new List<Scorm>();

    public virtual TeachingPlanner? TeachingPlanner { get; set; }
}
