using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document3SelectedTopic
{
    public int Id { get; set; }

    public int Document3Id { get; set; }

    public int? SelectedTopicsId { get; set; }

    public int? EquipmentId { get; set; }

    public int? SubjectRoomId { get; set; }

    public int? Slot { get; set; }

    public DateOnly? Time { get; set; }

    public virtual Document3 Document3 { get; set; } = null!;

    public virtual TeachingEquipment? Equipment { get; set; }

    public virtual SelectedTopic? SelectedTopics { get; set; }

    public virtual SubjectRoom? SubjectRoom { get; set; }
}
