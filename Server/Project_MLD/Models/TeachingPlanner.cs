using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class TeachingPlanner
{
    public int UserId { get; set; }

    public int ClassId { get; set; }

    public int SubjectId { get; set; }

    public int Id { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<Document4> Document4s { get; set; } = new List<Document4>();

    public virtual ICollection<Scorm> Scorms { get; set; } = new List<Scorm>();

    public virtual Subject Subject { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
