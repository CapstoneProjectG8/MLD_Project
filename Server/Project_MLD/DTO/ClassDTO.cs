using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class ClassDTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? TotalStudent { get; set; }

    public int? TotalStudentSelectedTopics { get; set; }

    public int GradeId { get; set; }

    public string? GradeName { get; set; }

}
