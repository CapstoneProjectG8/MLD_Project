using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document1PeriodicAssessmentDTO
{
    public int TestingCategoryId { get; set; }

    public int FormCategoryId { get; set; }

    public int? Time { get; set; }

    public DateOnly? Date { get; set; }

    public string? Description { get; set; }

    public int Document1Id { get; set; }

    public string? FormCategoryName { get; set; }

    public string? TestingCategoryName { get; set; }
}
