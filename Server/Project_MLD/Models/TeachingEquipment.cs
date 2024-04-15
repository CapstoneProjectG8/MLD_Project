using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class TeachingEquipment
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Document1TeachingEquipment> Document1TeachingEquipments { get; set; } = new List<Document1TeachingEquipment>();

    public virtual ICollection<Document3CurriculumDistribution> Document3CurriculumDistributions { get; set; } = new List<Document3CurriculumDistribution>();

    public virtual ICollection<Document3SelectedTopic> Document3SelectedTopics { get; set; } = new List<Document3SelectedTopic>();
}
