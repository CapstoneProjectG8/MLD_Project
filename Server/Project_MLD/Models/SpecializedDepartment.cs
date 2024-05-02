using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class SpecializedDepartment
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; } = new List<DepartmentSubject>();

    public virtual ICollection<UserDepartment> UserDepartments { get; set; } = new List<UserDepartment>();
}
