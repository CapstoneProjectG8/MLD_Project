using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document2DTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? UserId { get; set; }

    public bool? Status { get; set; }

    public int? ApproveBy { get; set; }

    public bool? IsApprove { get; set; }

}
