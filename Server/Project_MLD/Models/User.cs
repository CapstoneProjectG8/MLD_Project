using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? FullName { get; set; }

    public byte[]? Photo { get; set; }

    public string? Address { get; set; }

    public bool? Gender { get; set; }

    public string? PlaceOfBirth { get; set; }

    public int? Age { get; set; }

    public int? LevelOfTrainningId { get; set; }

    public int? SpecializedTeamId { get; set; }

    public int? AccountId { get; set; }

    public int? ProfessionalStandardsId { get; set; }

    public int? CreatedBy { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateOnly? ModifiedDate { get; set; }

    public bool? Active { get; set; }

    public virtual Account? Account { get; set; }

    public virtual LevelOfTrainning? LevelOfTrainning { get; set; }

    public virtual ICollection<PhuLuc1> PhuLuc1s { get; set; } = new List<PhuLuc1>();

    public virtual ICollection<PhuLuc2> PhuLuc2s { get; set; } = new List<PhuLuc2>();

    public virtual ICollection<PhuLuc3> PhuLuc3s { get; set; } = new List<PhuLuc3>();

    public virtual ICollection<PhuLuc5> PhuLuc5s { get; set; } = new List<PhuLuc5>();

    public virtual ProfessionalStandard? ProfessionalStandards { get; set; }

    public virtual SpecializedTeam? SpecializedTeam { get; set; }

    public virtual ICollection<TeachingPlanner> TeachingPlanners { get; set; } = new List<TeachingPlanner>();
}
