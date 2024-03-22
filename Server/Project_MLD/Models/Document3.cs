using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document3
{
    public int Id { get; set; }

    public int? Document1Id { get; set; }

    public int? UserId { get; set; }

    public bool? Status { get; set; }

    public virtual Document1? Document1 { get; set; }

    public virtual User? User { get; set; }
}
