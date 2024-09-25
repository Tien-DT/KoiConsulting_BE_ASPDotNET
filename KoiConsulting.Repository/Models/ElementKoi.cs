using System;
using System.Collections.Generic;

namespace KoiConsulting.Repository.Models;

public partial class ElementKoi
{
    public int Id { get; set; }

    public int ElementId { get; set; }

    public int KoiId { get; set; }

    public string? Type { get; set; }

    public virtual Element Element { get; set; } = null!;

    public virtual ElementKoiDetail IdNavigation { get; set; } = null!;

    public virtual KoiType Koi { get; set; } = null!;
}
