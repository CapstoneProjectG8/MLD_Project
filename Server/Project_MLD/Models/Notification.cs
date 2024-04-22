using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Notification
{
    public int Id { get; set; }

    public string? TitleName { get; set; }

    public int SentBy { get; set; }

    public int? ReceiveBy { get; set; }

    public string? Message { get; set; }

    public virtual User SentByNavigation { get; set; } = null!;
}
