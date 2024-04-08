using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class SubjectRoom
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Document1SubjectRoom> Document1SubjectRooms { get; set; } = new List<Document1SubjectRoom>();
}
