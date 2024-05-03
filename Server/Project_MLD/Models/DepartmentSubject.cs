using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class DepartmentSubject
{
    public int Id { get; set; }

    public int? DepartmentId { get; set; }

    public int? SubjectId { get; set; }

    public virtual SpecializedDepartment? Department { get; set; }

    public virtual Subject? Subject { get; set; }
}
