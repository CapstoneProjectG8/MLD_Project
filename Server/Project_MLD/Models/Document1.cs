using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document1
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? SubjectId { get; set; }

    public int? GradeId { get; set; }

    public int? UserId { get; set; }

    public string? Note { get; set; }

    public bool? Status { get; set; }

    public int? ApproveBy { get; set; }

    public bool? IsApprove { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? LinkFile { get; set; }

    public string? LinkImage { get; set; }

    public string? OtherTasks { get; set; }

    public virtual ICollection<Document1CurriculumDistribution> Document1CurriculumDistributions { get; set; } = new List<Document1CurriculumDistribution>();

    public virtual ICollection<Document1SelectedTopic> Document1SelectedTopics { get; set; } = new List<Document1SelectedTopic>();

    public virtual ICollection<Document1SubjectRoom> Document1SubjectRooms { get; set; } = new List<Document1SubjectRoom>();

    public virtual ICollection<Document1TeachingEquipment> Document1TeachingEquipments { get; set; } = new List<Document1TeachingEquipment>();

    public virtual ICollection<Document3> Document3s { get; set; } = new List<Document3>();

    public virtual Grade? Grade { get; set; }

    public virtual ICollection<PeriodicAssessment> PeriodicAssessments { get; set; } = new List<PeriodicAssessment>();

    public virtual Subject? Subject { get; set; }

    public virtual User? User { get; set; }
}
