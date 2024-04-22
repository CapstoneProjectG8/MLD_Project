using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document3DTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Document1Id { get; set; }

    public int? UserId { get; set; }

    public string? ClaasName { get; set; }

    public bool? Status { get; set; }

    public int? IsApprove { get; set; }

    public int? ApproveBy { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? LinkFile { get; set; }

    public string? LinkImage { get; set; }

    public string? OtherTasks { get; set; }

    public string? UserFullName { get; set; }
    public string? ApproveByName { get; set;}
    public string? Document1Name { get; set; }

}
