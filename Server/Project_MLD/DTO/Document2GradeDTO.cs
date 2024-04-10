using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document2GradeDTO
{
    public int Document2Id { get; set; }

    public int GradeId { get; set; }

    public string? TitleName { get; set; }

    public string? Description { get; set; }

    public int? Slot { get; set; }

    public DateOnly? Time { get; set; }

    public string? Place { get; set; }

    public string? HostBy { get; set; }

    public string? CollaborateWith { get; set; }

    public string? Condition { get; set; }

}
