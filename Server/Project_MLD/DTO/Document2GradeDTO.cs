﻿using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document2GradeDTO
{
    public int Id { get; set; }

    public int? Document2Id { get; set; }

    public int? GradeId { get; set; }

    public string? TitleName { get; set; }

    public string? Description { get; set; }

    public int? Slot { get; set; }

    public DateOnly? Time { get; set; }

    public string? Place { get; set; }

    public int? HostBy { get; set; }

    public string? CollaborateWith { get; set; }

    public string? Condition { get; set; }
    public string? HostByName { get; set; }
    public string? GradeName { get; set; }

}
