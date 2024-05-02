using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class UserDepartment
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? DepartmentId { get; set; }

    public virtual SpecializedDepartment? Department { get; set; }

    public virtual User? User { get; set; }
}
