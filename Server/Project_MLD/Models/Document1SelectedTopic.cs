using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document1SelectedTopic
{
    public int? Document1Id { get; set; }

    public int? SelectedTopicsId { get; set; }

    public int? Slot { get; set; }

    public string? Description { get; set; }

    public virtual Document1? Document1 { get; set; }

    public virtual SelectedTopic? SelectedTopics { get; set; }
}
