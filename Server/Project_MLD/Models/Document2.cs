using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project_MLD.Models;

public partial class Document2
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? UserId { get; set; }

    public bool? Status { get; set; }

    public int? ApproveBy { get; set; }

    public bool? IsApprove { get; set; }

    public virtual User? User { get; set; }
}
