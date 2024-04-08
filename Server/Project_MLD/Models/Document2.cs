using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document2
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? UserId { get; set; }

    public bool? Status { get; set; }

    public int? ApproveBy { get; set; }

    public bool? IsApprove { get; set; }

    public virtual ICollection<Document2Grade> Document2Grades { get; set; } = new List<Document2Grade>();

    public virtual User? User { get; set; }
}
