using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class CurriculumDistribution
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Document1CurriculumDistribution> Document1CurriculumDistributions { get; set; } = new List<Document1CurriculumDistribution>();
}
