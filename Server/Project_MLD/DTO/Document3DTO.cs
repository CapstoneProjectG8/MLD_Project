using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document3DTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Document1Id { get; set; }

    public int? UserId { get; set; }

    public bool? Status { get; set; }

    public bool? IsApprove { get; set; }

    public int? ApproveBy { get; set; }

}
