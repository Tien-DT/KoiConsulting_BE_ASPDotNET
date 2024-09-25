using System;
using System.Collections.Generic;

namespace KoiConsulting.Repository.Models;

public partial class KoiAttribute
{
    public int KoiId { get; set; }

    public string SubName { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string? Size { get; set; }

    public string? Origin { get; set; }

    public string? Img { get; set; }

    public virtual KoiType Koi { get; set; } = null!;
}
