using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Feedback
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Message { get; set; }

    public int? DocType { get; set; }

    public int? DocId { get; set; }

    public string? Description { get; set; }

    public virtual User? User { get; set; }
}
