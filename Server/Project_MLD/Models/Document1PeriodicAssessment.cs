﻿using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document1PeriodicAssessment
{
    public int TestingCategoryId { get; set; }

    public int FormCategoryId { get; set; }

    public int? Time { get; set; }

    public DateOnly? Date { get; set; }

    public string? Description { get; set; }

    public int Document1Id { get; set; }

    public virtual Document1 Document1 { get; set; } = null!;

    public virtual FormCategory FormCategory { get; set; } = null!;

    public virtual TestingCategory TestingCategory { get; set; } = null!;
}
