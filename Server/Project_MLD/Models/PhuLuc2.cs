using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class PhuLuc2
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? UserId { get; set; }

    public bool? Status { get; set; }

    public virtual User? User { get; set; }
}
