using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class SpecializedTeam
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
