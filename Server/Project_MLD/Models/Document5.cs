using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document5
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Document4Id { get; set; }

    public int? UserId { get; set; }

    public int? Total { get; set; }

    public virtual Document4 Document4 { get; set; } = null!;

    public virtual User? User { get; set; }
}
