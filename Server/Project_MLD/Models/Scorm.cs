using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Scorm
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public byte[]? Content { get; set; }

    public int TeachingPlannerId { get; set; }

    public bool? IsAprrove { get; set; }

    public bool? Status { get; set; }

    public string? LinkFile { get; set; }

    public string? LinkImage { get; set; }

    public virtual TeachingPlanner TeachingPlanner { get; set; } = null!;
}
