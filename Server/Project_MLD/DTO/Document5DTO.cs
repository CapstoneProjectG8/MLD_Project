using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document5DTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Document4Id { get; set; }

    public int UserId { get; set; }

    public int? Slot { get; set; }

    public DateOnly? Date { get; set; }

    public int? Total { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? LinkFile { get; set; }

    public string? LinkImage { get; set; }

    public string? UserFullName { get; set; }
}
