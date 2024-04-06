using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document1
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? SubjectId { get; set; }

    public int? GradeId { get; set; }

    public int? UserId { get; set; }

    public string? Note { get; set; }

    public bool? Status { get; set; }

    public int? ApproveBy { get; set; }

    public bool? IsApprove { get; set; }

    public virtual ICollection<Document3> Document3s { get; set; } = new List<Document3>();

    public virtual Grade? Grade { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual User? User { get; set; }
}
