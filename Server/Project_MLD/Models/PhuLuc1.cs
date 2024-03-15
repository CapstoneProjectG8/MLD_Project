using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class PhuLuc1
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? SubjectId { get; set; }

    public int? GradeId { get; set; }

    public int? UserId { get; set; }

    public string? Note { get; set; }

    public int? Status { get; set; }

    public int? ApproveBy { get; set; }

    public virtual Grade? Grade { get; set; }

    public virtual ICollection<PhuLuc3> PhuLuc3s { get; set; } = new List<PhuLuc3>();

    public virtual Subject? Subject { get; set; }

    public virtual User? User { get; set; }
}
