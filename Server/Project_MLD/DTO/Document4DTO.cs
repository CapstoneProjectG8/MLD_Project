using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document4DTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? TeachingPlannerId { get; set; }

    public bool? Status { get; set; }
}
