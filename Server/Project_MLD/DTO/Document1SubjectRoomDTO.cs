using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class Document1SubjectRoomDTO
{
    public int Id { get; set; }

    public int? SubjectRoomId { get; set; }

    public int Document1Id { get; set; }

    public int? Quantity { get; set; }

    public string? Description { get; set; }

    public string? Note { get; set; }

    public string? SubjectRoomName { get; set; }

}
