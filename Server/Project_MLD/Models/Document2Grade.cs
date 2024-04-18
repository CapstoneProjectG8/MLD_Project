using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document2Grade
{
    public int Document2Id { get; set; }

    public int GradeId { get; set; }

    public string? TitleName { get; set; }

    public string? Description { get; set; }

    public int? Slot { get; set; }

    public DateOnly? Time { get; set; }

    public string? Place { get; set; }

    public int HostBy { get; set; }

    public string? CollaborateWith { get; set; }

    public string? Condition { get; set; }

    public virtual Document2 Document2 { get; set; } = null!;

    public virtual Grade Grade { get; set; } = null!;

    public virtual User HostByNavigation { get; set; } = null!;
}
