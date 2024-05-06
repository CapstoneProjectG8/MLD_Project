using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? DepartmentId { get; set; }

    public virtual SpecializedDepartment? Department { get; set; }

    public virtual ICollection<Document1> Document1s { get; set; } = new List<Document1>();

    public virtual ICollection<TeachingPlanner> TeachingPlanners { get; set; } = new List<TeachingPlanner>();
}
