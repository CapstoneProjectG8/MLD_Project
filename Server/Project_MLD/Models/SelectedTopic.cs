using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class SelectedTopic
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Document1SelectedTopic> Document1SelectedTopics { get; set; } = new List<Document1SelectedTopic>();

    public virtual ICollection<Document3SelectedTopic> Document3SelectedTopics { get; set; } = new List<Document3SelectedTopic>();
}
