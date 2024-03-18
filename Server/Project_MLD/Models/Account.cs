using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public bool? Active { get; set; }

    public int? CreatedBy { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
