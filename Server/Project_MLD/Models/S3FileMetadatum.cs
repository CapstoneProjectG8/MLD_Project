using System;
using System.Collections.Generic;

namespace Project_MLD.Models;

public partial class S3FileMetadatum
{
    public int Id { get; set; }

    public string? FileKey { get; set; }

    public string? PresignedUrl { get; set; }

    public DateTime? ExpirationDatetime { get; set; }
}
