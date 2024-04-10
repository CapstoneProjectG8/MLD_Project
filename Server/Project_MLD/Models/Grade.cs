using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Grade
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? TotalStudent { get; set; }

    public int? TotalStudentSelectedTopics { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Document1> Document1s { get; set; } = new List<Document1>();

    public virtual ICollection<Document2Grade> Document2Grades { get; set; } = new List<Document2Grade>();
}
