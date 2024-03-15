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

    public virtual ICollection<PhuLuc1> PhuLuc1s { get; set; } = new List<PhuLuc1>();
}
