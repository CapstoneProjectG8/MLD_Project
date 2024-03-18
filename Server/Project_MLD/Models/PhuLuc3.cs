﻿using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class PhuLuc3
{
    public int Id { get; set; }

    public int? Pl1Id { get; set; }

    public int? UserId { get; set; }

    public bool? Status { get; set; }

    public virtual PhuLuc1? Pl1 { get; set; }

    public virtual User? User { get; set; }
}
