using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Pl1SubjectRoom
{
    public int? SubjectRoomId { get; set; }

    public int? Pl1Id { get; set; }

    public int? Quantity { get; set; }

    public string? Description { get; set; }

    public string? Note { get; set; }

    public virtual PhuLuc1? Pl1 { get; set; }

    public virtual SubjectRoom? SubjectRoom { get; set; }
}
