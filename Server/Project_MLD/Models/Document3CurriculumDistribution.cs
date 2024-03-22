using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document3CurriculumDistribution
{
    public int? Document3Id { get; set; }

    public int? CurriculumId { get; set; }

    public int? Slot { get; set; }

    public DateOnly? Time { get; set; }

    public int TeachingEquipmentId { get; set; }

    public string? Place { get; set; }

    public virtual CurriculumDistribution? Curriculum { get; set; }

    public virtual Document3? Document3 { get; set; }

    public virtual TeachingEquipment TeachingEquipment { get; set; } = null!;
}
