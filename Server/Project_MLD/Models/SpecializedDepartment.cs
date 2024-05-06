using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class SpecializedDepartment
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
