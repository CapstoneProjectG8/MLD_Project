using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document3CurriculumDistribution
{
    public int Id { get; set; }

    public int Document3Id { get; set; }

    public int? CurriculumId { get; set; }

    public int? EquipmentId { get; set; }

    public int? SubjectRoomId { get; set; }

    public int? Slot { get; set; }

    public DateOnly? Time { get; set; }

    public virtual CurriculumDistribution? Curriculum { get; set; }

    public virtual Document3 Document3 { get; set; } = null!;

    public virtual TeachingEquipment? Equipment { get; set; }

    public virtual SubjectRoom? SubjectRoom { get; set; }
}
