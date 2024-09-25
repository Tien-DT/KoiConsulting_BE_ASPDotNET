using System;
using System.Collections.Generic;

namespace KoiConsulting.Repository.Models;

public partial class ElementKoiDetail
{
    public int ElementKoiId { get; set; }

    public int KoiId { get; set; }

    public int? Quantity { get; set; }

    public int? AppropriateLevel { get; set; }

    public string? Detail { get; set; }

    public virtual ICollection<ElementKoi> ElementKois { get; set; } = new List<ElementKoi>();

    public virtual KoiType Koi { get; set; } = null!;
}
