using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class FormCategory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Document1PeriodicAssessment> Document1PeriodicAssessments { get; set; } = new List<Document1PeriodicAssessment>();
}
