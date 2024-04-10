using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class TestingCategory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<PeriodicAssessment> PeriodicAssessments { get; set; } = new List<PeriodicAssessment>();
}
