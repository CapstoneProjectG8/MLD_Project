using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document2DTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int UserId { get; set; }

    public bool? Status { get; set; }

    public int? ApproveBy { get; set; }

    public int? IsApprove { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? LinkFile { get; set; }

    public string? LinkImage { get; set; }

    public string? ApproveByName { get; set; }

    public string? UserName { get; set; }
}
