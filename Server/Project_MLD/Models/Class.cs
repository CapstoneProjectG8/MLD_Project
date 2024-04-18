using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Class
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? TotalStudent { get; set; }

    public int? TotalStudentSelectedTopics { get; set; }

    public int GradeId { get; set; }

    public virtual Grade Grade { get; set; } = null!;

    public virtual ICollection<TeachingPlanner> TeachingPlanners { get; set; } = new List<TeachingPlanner>();
}
