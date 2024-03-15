using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class TeachingPlanner
{
    public int? UserId { get; set; }

    public int? ClassId { get; set; }

    public int? SubjectId { get; set; }

    public int Id { get; set; }

    public virtual Class? Class { get; set; }

    public virtual ICollection<PhuLuc4> PhuLuc4s { get; set; } = new List<PhuLuc4>();

    public virtual Subject? Subject { get; set; }

    public virtual User? User { get; set; }
}
