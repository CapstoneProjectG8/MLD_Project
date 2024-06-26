﻿using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Scorm> Scorms { get; set; } = new List<Scorm>();
}
