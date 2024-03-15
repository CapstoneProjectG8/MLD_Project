using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Pl3CurriculumDistribution
{
    public int? Pl3Id { get; set; }

    public int? CurriculumId { get; set; }

    public int? Slot { get; set; }

    public DateOnly? Time { get; set; }

    public int TeachingEquipmentId { get; set; }

    public string? Place { get; set; }

    public virtual CurriculumDistribution? Curriculum { get; set; }

    public virtual PhuLuc3? Pl3 { get; set; }

    public virtual TeachingEquipment TeachingEquipment { get; set; } = null!;
}
