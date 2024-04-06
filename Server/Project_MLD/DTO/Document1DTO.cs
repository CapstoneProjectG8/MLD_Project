using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document1DTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? SubjectId { get; set; }

    public int? GradeId { get; set; }

    public int? UserId { get; set; }

    public string? Note { get; set; }

    public bool? Status { get; set; }

    public string? ApproveByName { get; set; }

}
