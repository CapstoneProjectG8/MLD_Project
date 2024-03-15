using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class LoginAttempt
{
    public int Id { get; set; }

    public string? AccountName { get; set; }

    public string? Password { get; set; }

    public bool? Success { get; set; }

    public DateOnly? CreatedDate { get; set; }
}
