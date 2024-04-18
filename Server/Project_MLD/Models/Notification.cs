using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Notification
{
    public int Id { get; set; }

    public string? TitleName { get; set; }

    public string? Type { get; set; }

    public int UserId { get; set; }

    public string? Message { get; set; }

    public virtual User User { get; set; } = null!;
}
