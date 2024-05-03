using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document1SubjectRoom
{
    public int Id { get; set; }

    public int? SubjectRoomId { get; set; }

    public int Document1Id { get; set; }

    public int? Quantity { get; set; }

    public string? Description { get; set; }

    public string? Note { get; set; }

    public virtual Document1 Document1 { get; set; } = null!;

    public virtual SubjectRoom? SubjectRoom { get; set; }
}
