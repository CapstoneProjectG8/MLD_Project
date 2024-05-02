using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class IsApprove
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Document1> Document1s { get; set; } = new List<Document1>();

    public virtual ICollection<Document2> Document2s { get; set; } = new List<Document2>();

    public virtual ICollection<Document3> Document3s { get; set; } = new List<Document3>();

    public virtual ICollection<Document4> Document4s { get; set; } = new List<Document4>();
}
