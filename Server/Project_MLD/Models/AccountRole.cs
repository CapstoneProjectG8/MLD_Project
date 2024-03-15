using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class AccountRole
{
    public int? AccountId { get; set; }

    public int? RoleId { get; set; }

    public int? CreatedBy { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Role? Role { get; set; }
}
