using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Feedback
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Content { get; set; }

    public virtual User? User { get; set; }
}
