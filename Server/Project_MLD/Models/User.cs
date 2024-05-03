using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? FullName { get; set; }

    public string? Photo { get; set; }

    public string? Address { get; set; }

    public bool? Gender { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public int? Age { get; set; }

    public int? LevelOfTrainningId { get; set; }

    public int AccountId { get; set; }

    public int? ProfessionalStandardsId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Document1> Document1s { get; set; } = new List<Document1>();

    public virtual ICollection<Document2Grade> Document2Grades { get; set; } = new List<Document2Grade>();

    public virtual ICollection<Document2> Document2s { get; set; } = new List<Document2>();

    public virtual ICollection<Document3> Document3s { get; set; } = new List<Document3>();

    public virtual ICollection<Document5> Document5s { get; set; } = new List<Document5>();

    public virtual LevelOfTrainning? LevelOfTrainning { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ProfessionalStandard? ProfessionalStandards { get; set; }

    public virtual Report? Report { get; set; }

    public virtual ICollection<TeachingPlanner> TeachingPlanners { get; set; } = new List<TeachingPlanner>();

    public virtual ICollection<UserDepartment> UserDepartments { get; set; } = new List<UserDepartment>();
}
