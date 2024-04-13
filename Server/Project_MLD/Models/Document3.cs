using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document3
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Document1Id { get; set; }

    public int? UserId { get; set; }

    public bool? Status { get; set; }

    public bool? IsApprove { get; set; }

    public int? ApproveBy { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? LinkFile { get; set; }

    public string? LinkImage { get; set; }

    public string? OtherTasks { get; set; }

    public virtual Document1? Document1 { get; set; }

    public virtual ICollection<Document3CurriculumDistribution> Document3CurriculumDistributions { get; set; } = new List<Document3CurriculumDistribution>();

    public virtual ICollection<Document3SelectedTopic> Document3SelectedTopics { get; set; } = new List<Document3SelectedTopic>();

    public virtual User? User { get; set; }
}
