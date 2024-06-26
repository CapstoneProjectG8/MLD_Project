﻿using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document1TeachingEquipment
{
    public int Id { get; set; }

    public int Document1Id { get; set; }

    public int? TeachingEquipmentId { get; set; }

    public int? Quantity { get; set; }

    public string? Note { get; set; }

    public string? Description { get; set; }

    public virtual Document1 Document1 { get; set; } = null!;

    public virtual TeachingEquipment? TeachingEquipment { get; set; }
}
