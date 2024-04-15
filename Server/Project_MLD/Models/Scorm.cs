using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Scorm
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public byte[]? Content { get; set; }

    public int CategoryId { get; set; }

    public int Document4Id { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Document4 Document4 { get; set; } = null!;
}
