using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Scorm
{
    public string Id { get; set; } = null!;

    public byte[]? Content { get; set; }
}
