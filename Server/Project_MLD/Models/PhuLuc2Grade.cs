using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class PhuLuc2Grade
{
    public int? Pl2Id { get; set; }

    public int? GradeId { get; set; }

    public string? TitleName { get; set; }

    public string? Description { get; set; }

    public int? Slot { get; set; }

    public DateOnly? Time { get; set; }

    public string? Place { get; set; }

    public string? HostBy { get; set; }

    public string? CollaborateWith { get; set; }

    public string? Condition { get; set; }

    public virtual Grade? Grade { get; set; }

    public virtual PhuLuc2? Pl2 { get; set; }
}
