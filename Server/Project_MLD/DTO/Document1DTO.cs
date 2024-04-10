using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document1DTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? SubjectName { get; set; }

    public string? GradeName { get; set; }

    public string? UserName { get; set; }

    public string? Note { get; set; }

    public bool? Status { get; set; }

    public string? ApproveByName { get; set; }

}
