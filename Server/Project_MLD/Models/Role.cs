using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public string? RoleNote { get; set; }

    public bool? Active { get; set; }

    public int? CreatedBy { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateOnly? ModifiedDate { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
