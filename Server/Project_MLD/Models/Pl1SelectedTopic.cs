using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Pl1SelectedTopic
{
    public int? Pl1Id { get; set; }

    public int? SelectedTopicsId { get; set; }

    public int? Slot { get; set; }

    public string? Description { get; set; }

    public virtual PhuLuc1? Pl1 { get; set; }

    public virtual SelectedTopic? SelectedTopics { get; set; }
}
