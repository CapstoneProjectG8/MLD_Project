using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document4DTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int TeachingPlannerId { get; set; }

    public bool? Status { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? LinkFile { get; set; }

    public string? LinkImage { get; set; }

    public int? IsApprove { get; set; }

    public string? UserName { get; set; }
    public string? ClassName { get; set; }
    public string? SubjectName { get; set; }
}
