using System;
using System.Collections.Generic;

namespace SWP.KoiConsulting.Repository.Models;

public partial class KoiAttribute
{
    public int Id { get; set; }

    public string? SubName { get; set; }

    public string? Color { get; set; }

    public string? Size { get; set; }

    public string? Origin { get; set; }

    public string? Img { get; set; }

    public int? Status { get; set; }

    public virtual KoiAttributeGroup IdNavigation { get; set; } = null!;
}
