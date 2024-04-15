using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document3SelectedTopic
{
    public int Document3Id { get; set; }

    public int SelectedTopicsId { get; set; }

    public int EquipmentId { get; set; }

    public string? SubjectRoomName { get; set; }

    public int? Slot { get; set; }

    public DateOnly? Time { get; set; }

    public virtual Document3 Document3 { get; set; } = null!;

    public virtual TeachingEquipment Equipment { get; set; } = null!;

    public virtual SelectedTopic SelectedTopics { get; set; } = null!;
}
